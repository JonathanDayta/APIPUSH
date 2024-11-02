using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace Attendance
{
    /// <summary>Device Management
    /// </summary>
    public partial class UCDevice : UserControl
    {
        //Device number and device polling time dictionary
        private Dictionary<String, int> _dicDevInterval = new Dictionary<String, int>();

        private string[] devCmd = new string[100];
        DeviceBll _bll = new DeviceBll();
        ZonaClienteBll _bllCom = new ZonaClienteBll();
        DeptoSucursalBll _bllDepto = new DeptoSucursalBll();
        DataTable _dtDevice = null;
        List<ZonaClienteModel> lstClientes = new List<ZonaClienteModel>();

        public UCDevice()
        {
            InitializeComponent();
        }

        /// <summary>Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCDevice_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.dgvDevice.AutoGenerateColumns = false;
            LoadDevice();
            LoadClients();
            if (_dtDevice == null || _dtDevice.Rows.Count != 0)
            {
                foreach (DataRow dr in _dtDevice.Rows)
                {
                    string sn = dr["DevSN"].ToString();
                    int delay = Tools.TryConvertToInt32(dr["Delay"]);
                    if (!_dicDevInterval.ContainsKey(sn))
                    {
                        _dicDevInterval.Add(sn, 0);
                    }
                }
            }
            
            this.timerGetDevStatus.Enabled = true;
            this.timerGetDevStatus.Interval = 1000;
        }

        /// <summary>Load Device Data
        /// </summary>
        private void LoadDevice()
        {
            _dtDevice = _bll.GetAll("");
            this.dgvDevice.DataSource = _dtDevice;
        }

        /// <summary>
        /// Load the data from the customer combo box
        /// </summary>
        private void LoadClients()
        {
            lstClientes = _bllCom.GetClientes();
            this.cmbZone.DataSource = lstClientes;
            this.cmbZone.DisplayMember = "nomCliente";
            this.cmbZone.ValueMember = "idZonaCliente";
        }

        /// <summary>
        /// Load the data from the department combo box given the customer id
        /// </summary>
        /// <param name="idClient"></param>
        private void LoadDepartments(int idClient)
        {
            List<DeptoSucursalModel> lst = _bllDepto.GetDeptoSucursalByIdClient(idClient);
            //Si no hay sucursales del cliente seleccionado
            if (lst.Count == 0)
            {
                DeptoSucursalModel depto = new DeptoSucursalModel();
                depto.idDeptoSucursal = 0;
                depto.nomSucursal = "SIN SUCURSAL";
                lst.Add(depto);
            }

            this.cmbDepartment.DataSource = lst;
            this.cmbDepartment.DisplayMember = "nomSucursal";
            this.cmbDepartment.ValueMember = "idDeptoSucursal";
        }

        /// <summary>New Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.lblMsg.Visible = false;

            DeviceModel device = new DeviceModel();
            txtDevSN.Text = device.DevSN;
            txtDevName.Text = device.DevName;
            txtTransFlag.Text = device.TransFlag;
            cmbTimeZone.Text = device.TimeZone;
            cmbZone.SelectedIndex = device.IdDeptoSucursal;
        }

        /// <summary>Save Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDevSN.Text))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please input Device SN";
                return;
            }

            lblMsg.Visible = false;

            //Device Exsit,Update
            DeviceModel device;
            if (null != (device = _bll.Get(txtDevSN.Text.Trim())))
            {
                device.TimeZone = cmbTimeZone.Text;
                device.DevName = txtDevName.Text;

                String tmp = txtTransFlag.Text.Trim();
                if (tmp.Length >= 150)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "The data in the Transflag field exceeds the allowed length.";
                    return;
                }
                device.TransFlag = tmp;
                try
                {
                    if (_bll.Update(device) > 0)
                    {
                        LoadDevice();
                        lblMsg.Visible = true;
                        lblMsg.Text = "Update device success";
                        btnAdd_Click(sender, e);
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Update device fail";
                    }
                    return;
                }
                catch { }
            }

            //Device No Exist,Add
            lblMsg.Visible = false;
            device = new DeviceModel();
            device.DevSN = txtDevSN.Text.Trim();
            device.TimeZone = cmbTimeZone.Text;
            device.DevName = txtDevName.Text;
            device.TransFlag = txtTransFlag.Text.Trim();
            if ((DeptoSucursalModel)this.cmbDepartment.SelectedItem == null)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "There is no information about the department.";
                return;
            }
            else
            {
                device.IdDeptoSucursal = ((DeptoSucursalModel)this.cmbDepartment.SelectedItem).idDeptoSucursal;
                try
                {
                    if (!ValidaClienteSucursal(device))
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "You must select a client and department.";
                        return;
                    }
                    else if (device.TransFlag.Length >= 150)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "The data in the Transflag field exceeds the allowed length.";
                        return;
                    }
                    else
                    {
                        if (_bll.Add(device) > 0)
                        {
                            LoadDevice();
                            if (!_dicDevInterval.ContainsKey(device.DevSN))
                            {
                                _dicDevInterval.Add(device.DevSN, 0);
                            }

                            lblMsg.Visible = true;
                            lblMsg.Text = "Add device SN " + txtDevSN.Text.Trim() + " success";
                            btnAdd_Click(sender, e);
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Add device SN " + txtDevSN.Text.Trim() + " fail";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = ex.ToString();
                }
            }
        }

        /// <summary>
        /// Validates that the customer and branch data is selected
        /// </summary>
        /// <param name="dm">DeviceModel</param>
        /// <returns>true if the data exists and false otherwise</returns>
        private Boolean ValidaClienteSucursal(DeviceModel dm)
        {
            Boolean isOk = false;
            if (dm.IdDeptoSucursal != 0)
                isOk = true;

            return isOk;
        }

        /// <summary>Delete Device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDevSN.Text))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please Input Device SN first";
                return;
            }
            string devSN = txtDevSN.Text.Trim();
            DeviceModel device;
            if (null == (device = _bll.Get(devSN)))
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Device SN is not exist";
                return;
            }
            lblMsg.Visible = false;

            if (_bll.Delete(devSN) > 0)
            {
                LoadDevice();
                _dicDevInterval.Remove(devSN);

                lblMsg.Visible = true;
                lblMsg.Text = "Remove device success";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Remove device fail";
            }
        }
        /// <summary>Send
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        /// <summary>Selected a Row 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDevice_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            //Right-click to also select the row
            if (e.Button == MouseButtons.Right)
            {
                this.dgvDevice.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
            if (this.dgvDevice.CurrentRow == null)
                return;

            DataGridViewRow row = dgvDevice.CurrentRow;
            this.txtDevSN.Text = row.Cells["colDevSN"].Value.ToString();
            this.txtDevName.Text = row.Cells["colDevName"].Value.ToString();
            this.txtTransFlag.Text = row.Cells["colTransFlag"].Value.ToString();
            this.cmbTimeZone.Text = row.Cells["colTimeZone"].Value.ToString();

            int idDeptoSuc = Tools.TryConvertToInt32(row.Cells["colDepartment"].Value.ToString());
            int idCliente = _bllDepto.GetIdCliente(idDeptoSuc);
            int index = GetIndexArrayClients(lstClientes, idCliente);
            this.cmbZone.SelectedIndex = index;
        }

        /// <summary>
        /// Find the index of the selected object
        /// </summary>
        /// <param name="lst">Element list</param>
        /// <param name="id">Id Element</param>
        /// <returns>Index ID</returns>
        private int GetIndexArrayClients(List<ZonaClienteModel> lst, int id)
        {
            int idSearch = 0;
            ZonaClienteModel zcm;
            for (int i = 0; i < lst.Count; i++)
            {
                zcm = (ZonaClienteModel)lst[i];
                if (zcm.idZonaCliente == id)
                    idSearch = i;
            }
            return idSearch;
        }

        /// <summary>Set devcie off-line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGetDevStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
                {
                    string devSN = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                    if (!_dicDevInterval.ContainsKey(devSN))
                        continue;

                    int devDelay = Tools.TryConvertToInt32(_dtDevice.Rows[i]["Delay"]);
                    if (devDelay > _dicDevInterval[devSN])
                    {
                        _dicDevInterval[devSN] += 1;//add 1s
                        continue;
                    }

                    _dicDevInterval[devSN] = 0;//reset
                    this.dgvDevice.Rows[i].Cells["colStatus"].Value = Properties.Resources.imgDevStatus1;//Set device off-line .Receive msg from device,set it on-line.
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>Update Device Mask Status
        /// </summary>
        /// <param name="devSN"></param>
        /// <param name="maskStatus">0:no detected;1:detected successful;2:disable/notfound</param>
        public void UpdateDeviceMask(string devSN, int maskStatus)
        {
            for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
            {
                string sn = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                if (devSN != sn)
                    continue;

                string maskDesc = "";
                switch (maskStatus)
                {
                    case 0:
                        maskDesc = "No";
                        break;
                    case 1:
                        maskDesc = "Yes";
                        break;
                    case 2:
                        maskDesc = "";
                        break;
                    default:
                        break;
                }

                this.dgvDevice.Rows[i].Cells["colMask"].Value = maskDesc;
            }
        }
        /// <summary>Update Device Temperature
        /// </summary>
        /// <param name="devSN"></param>
        /// <param name="tempVal">Temperature</param>
        public void UpdateDeviceTemp(string devSN, string tempVal)
        {
            for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
            {
                string sn = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                if (devSN != sn)
                    continue;

                tempVal = (string.IsNullOrEmpty(tempVal)) ? "Disable/NotFound" : tempVal;

                this.dgvDevice.Rows[i].Cells["colTemp"].Value = tempVal;
            }
        }

        /// <summary>Update Device Info
        /// </summary>
        /// <param name="dev"></param>
        public void UpdateDevice(DeviceModel dev)
        {
            for (int i = 0; i < this.dgvDevice.Rows.Count; i++)
            {
                string devSN = this.dgvDevice.Rows[i].Cells["colDevSN"].Value.ToString();
                if (dev.DevSN != devSN)
                    continue;

                this.dgvDevice.Rows[i].Cells["colStatus"].Value = Properties.Resources.imgDevStatus2;//Set device on-line.
                if (_dicDevInterval.ContainsKey(devSN))
                {
                    _dicDevInterval[devSN] = 0;
                }

                this.dgvDevice.Rows[i].Cells["colDevIP"].Value = dev.DevIP;
                this.dgvDevice.Rows[i].Cells["colFirmwareVersion"].Value = dev.DevFirmwareVersion;
                this.dgvDevice.Rows[i].Cells["colDepartment"].Value = dev.IdDeptoSucursal;
            }
        }

        private void cbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZonaClienteModel cliente = (ZonaClienteModel) this.cmbZone.SelectedItem;
            System.Console.WriteLine("Cliente seleccionado: " + cliente.idZonaCliente);
            LoadDepartments(cliente.idZonaCliente);
        }

        private void cbDeparment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptoSucursalModel depto = (DeptoSucursalModel)this.cmbDepartment.SelectedItem;
            System.Console.WriteLine("Departamento seleccionado: " + depto.idDeptoSucursal);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDevice();
        }
    }
}

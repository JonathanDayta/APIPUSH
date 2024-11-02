using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Model;
using Model.DTO;
using Utils;

namespace Attendance
{
    public partial class UCMigrationLoad : UserControl
    {
        private DeviceBll _DeviceBll = new DeviceBll();
        private TblEmpleadoBll _EmpleadoBll = new TblEmpleadoBll();
        private UserInfoBll _Userbll = new UserInfoBll();

        List<TblEmpleadoModel> lstEmpleados = null;
        List<UsuarioCargaDto> lstCarga = null;

        public UCMigrationLoad()
        {
            InitializeComponent();
        }

        private void UCMigrationLoad_Load(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            cmbDevice.Enabled = false;
            LoadDeviceSN();
        }

        private void LoadDeviceSN()
        {
            cmbDevice.Items.Clear();
            
            try
            {
                List<string> listDevSN = _DeviceBll.GetAllDevSN();

                for (int i = 0; i < listDevSN.Count; i++)
                {
                    cmbDevice.Items.Add(listDevSN[i]); //添加在Device选择项中
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Device Message error:" + ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (StringExtension.isNotNullEmptyBlank(txtxSearchSite.Text))
            {
                lstEmpleados = _EmpleadoBll.GetTblEmpleadosBySite(txtxSearchSite.Text);
                if (lstEmpleados != null && lstEmpleados.Count > 0)
                {
                    dgvCargaDatos.DataSource = lstEmpleados;
                    cmbDevice.Enabled = true;
                    btnLoad.Enabled = true;
                    this.lblTituloGrid.Text = "Employee to be loaded: " + lstEmpleados.Count;
                }
                else
                {
                    this.lblTituloGrid.Text = "Employee to be loaded: 0";
                    MessageBox.Show("No data exists with the site provided.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                this.lblTituloGrid.Text = "Employee to be loaded: 0";
                MessageBox.Show("Requires site information.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (lstEmpleados != null && lstEmpleados.Count > 0)
            {
                string deviceSN = (string) cmbDevice.SelectedItem;
                System.Console.WriteLine("Biometrico seleccionado: " + deviceSN);

                if (StringExtension.isNotNullEmptyBlank(deviceSN))
                {
                    lstCarga = new List<UsuarioCargaDto>();
                    UsuarioCargaDto dto = null;
                    foreach (TblEmpleadoModel emp in lstEmpleados)
                    {
                        dto = new UsuarioCargaDto();
                        dto.PIN = emp.numEmpleado.ToString();
                        dto.Nombre = emp.nombre;
                        dto.SerialNumber = deviceSN;
                        lstCarga.Add(dto);
                    }

                    string message = "¿Confirm uploading employees to the selected biometric?";
                    string title = "Confirmation";

                    DialogResult dr = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        this.UseWaitCursor = true;

                        //envio aprocesar el contenido
                        _Userbll.AddUsers(lstCarga);

                        btnLoad.Enabled = false;
                        cmbDevice.Enabled = false;

                        Cursor.Current = Cursors.Default;
                        this.UseWaitCursor = false;

                        MessageBox.Show("The employees were uploaded to the biometric with serial number " + deviceSN, "Successful processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}

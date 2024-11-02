using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Model.DTO;
using BLL;

namespace Attendance
{
    public partial class UCBulkLoad : UserControl
    {
        List<UsuarioCargaDto> lstCarga = null;
        List<string> lstError = new List<string>();
        bool esAlta = false;
        bool esBaja = false;
        private UserInfoBll _bll = new UserInfoBll();

        public UCBulkLoad()
        {
            InitializeComponent();
            lblValidation.Text = string.Empty;
            btnProcess.Enabled = false;
            btnBrowsefile.Enabled = false;
            lblSinError.Visible = false;
        }

        private void btnBrowsefile_Click(object sender, EventArgs e)
        {
            lblSinError.Visible = false;
            openFileDialog.InitialDirectory = "C://";
            //Your opendialog box title name.
            openFileDialog.Title = "Select the file to upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog.Filter = "Select a valid document(*.csv)|*.csv";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog.FilterIndex = 1;
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists)
                    {
                        string filename = System.IO.Path.GetFullPath(openFileDialog.FileName);
                        lblFilepath.Text = "File: " + filename;

                        if (filename == null)
                        {
                            MessageBox.Show("Please select a valid document.");
                        }
                        else
                        {
                            lstCarga = new List<UsuarioCargaDto>();
                            //lstCargaBaja = new List<UsuarioCargaDto>();
                            lblValidation.Text = string.Empty;
                            lstError.Clear();
                            btnProcess.Enabled = false;

                            UsuarioCargaDto usuarioCarga = null;
                            using (StreamReader reader = new StreamReader(filename))
                            {
                                string line;
                                string[] data = null;
                                int count = 1;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    //Console.WriteLine(line);
                                    data = line.Split(',');
                                    usuarioCarga = new UsuarioCargaDto();
                                    if (data.Length == 2)
                                    {
                                        usuarioCarga.SerialNumber = data[0];
                                        usuarioCarga.PIN = data[1];
                                        usuarioCarga.Nombre = string.Empty;
                                        lstCarga.Add(usuarioCarga);
                                        if (esAlta)
                                        {
                                            lstError.Add("The row " + count + ", does not have the required parameters.");
                                        }
                                    }
                                    else if (data.Length == 3)
                                    {
                                        usuarioCarga.PIN = data[0];
                                        usuarioCarga.Nombre = data[1];
                                        usuarioCarga.SerialNumber = data[2];
                                        lstCarga.Add(usuarioCarga);
                                        if (esBaja)
                                        {
                                            lstError.Add("The row " + count + ", exceeds required parameters.");
                                        }
                                    }
                                    else
                                    {
                                        lstError.Add("The number of parameters exceeds the expected.");
                                    }
                                    count++;
                                }

                                
                                if (lstError.Count > 0)
                                {
                                    string errores = null;
                                    foreach(string err in lstError)
                                    {
                                        errores += err + "\n";
                                    }
                                    lblValidation.Text = "List of errors: \n" + errores;
                                    lblValidation.ForeColor = System.Drawing.Color.Red;
                                }
                                CargaVistaPrevia();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please upload a document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaVistaPrevia()
        {
            if (lstCarga != null && lstCarga.Count > 0)
            {
                dgvCargaDatos.DataSource = lstCarga;
            }

            if (lstError.Count == 0)
            {
                lblValidation.Text = string.Empty;
                lblSinError.Visible = true;
                btnProcess.Enabled = true;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string message = "¿Confirm processing of the uploaded file?";
            string title = "Confirmation";

            DialogResult dr = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.UseWaitCursor = true;

                //envio aprocesar el contenido
                if (esAlta)
                {
                    Console.WriteLine("Dando de alta .... ");
                    _bll.AddUsers(lstCarga);
                } else
                {
                    Console.WriteLine("Dando de baja .... ");
                    _bll.DeleteUsers(lstCarga);
                }

                lblFilepath.Text = "File ...";
                dgvCargaDatos.DataSource = new List<UsuarioCargaDto>();
                btnProcess.Enabled = false;
                lblSinError.Visible = false;
                rbAltaUsuarios.Checked = false;
                rbBajaUsuarios.Checked = false;

                Cursor.Current = Cursors.Default;
                this.UseWaitCursor = false;

                MessageBox.Show("The file was processed successfully,", "Successful processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbAltaUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            btnBrowsefile.Enabled = true;
            btnProcess.Enabled = false;
            lblSinError.Visible = false;
            esAlta = true;
            esBaja = false;
            lblFilepath.Text = "File ...";
            dgvCargaDatos.DataSource = new List<UsuarioCargaDto>();
            lstError.Clear();
        }

        private void rbBajaUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            btnBrowsefile.Enabled = true;
            btnProcess.Enabled = false;
            lblSinError.Visible = false;
            esBaja = true;
            esAlta = false;
            lblFilepath.Text = "File ...";
            dgvCargaDatos.DataSource = new List<UsuarioCargaDto>();
            lstError.Clear();
        }
    }
}

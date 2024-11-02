
namespace Attendance
{
    partial class UCBulkLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblModuleName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloGrid = new System.Windows.Forms.Label();
            this.dgvCargaDatos = new System.Windows.Forms.DataGridView();
            this.PIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblValidation = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnBrowsefile = new System.Windows.Forms.Button();
            this.lblFilepath = new System.Windows.Forms.Label();
            this.lblPanelTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbAltaUsuarios = new System.Windows.Forms.RadioButton();
            this.rbBajaUsuarios = new System.Windows.Forms.RadioButton();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.lblTituloCarga = new System.Windows.Forms.Label();
            this.lblTitulovalidacion = new System.Windows.Forms.Label();
            this.lblSinError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargaDatos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblModuleName
            // 
            this.lblModuleName.AutoSize = true;
            this.lblModuleName.Font = new System.Drawing.Font("Arial", 12F);
            this.lblModuleName.Location = new System.Drawing.Point(12, 14);
            this.lblModuleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(97, 23);
            this.lblModuleName.TabIndex = 1;
            this.lblModuleName.Text = "Bulk Load";
            this.lblModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTituloGrid);
            this.panel1.Controls.Add(this.dgvCargaDatos);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 743);
            this.panel1.TabIndex = 4;
            // 
            // lblTituloGrid
            // 
            this.lblTituloGrid.AutoSize = true;
            this.lblTituloGrid.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloGrid.Location = new System.Drawing.Point(13, 13);
            this.lblTituloGrid.Name = "lblTituloGrid";
            this.lblTituloGrid.Size = new System.Drawing.Size(147, 19);
            this.lblTituloGrid.TabIndex = 1;
            this.lblTituloGrid.Text = "Data to be loaded";
            // 
            // dgvCargaDatos
            // 
            this.dgvCargaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargaDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PIN,
            this.Nombre,
            this.SerialNumber,
            this.Password,
            this.UserType});
            this.dgvCargaDatos.Location = new System.Drawing.Point(-1, 33);
            this.dgvCargaDatos.Name = "dgvCargaDatos";
            this.dgvCargaDatos.ReadOnly = true;
            this.dgvCargaDatos.RowHeadersWidth = 51;
            this.dgvCargaDatos.RowTemplate.Height = 24;
            this.dgvCargaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargaDatos.Size = new System.Drawing.Size(904, 705);
            this.dgvCargaDatos.TabIndex = 0;
            // 
            // PIN
            // 
            this.PIN.DataPropertyName = "PIN";
            this.PIN.HeaderText = "PIN";
            this.PIN.MinimumWidth = 6;
            this.PIN.Name = "PIN";
            this.PIN.ReadOnly = true;
            this.PIN.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Name";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "SerialNumber";
            this.SerialNumber.MinimumWidth = 6;
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            this.SerialNumber.Width = 125;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 125;
            // 
            // UserType
            // 
            this.UserType.DataPropertyName = "UserType";
            this.UserType.HeaderText = "UserType";
            this.UserType.MinimumWidth = 6;
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.Width = 125;
            // 
            // lblValidation
            // 
            this.lblValidation.AutoSize = true;
            this.lblValidation.Font = new System.Drawing.Font("Arial", 10F);
            this.lblValidation.Location = new System.Drawing.Point(930, 283);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(84, 19);
            this.lblValidation.TabIndex = 5;
            this.lblValidation.Text = "Validation:";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(1272, 212);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(125, 27);
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnBrowsefile
            // 
            this.btnBrowsefile.Location = new System.Drawing.Point(1304, 170);
            this.btnBrowsefile.Name = "btnBrowsefile";
            this.btnBrowsefile.Size = new System.Drawing.Size(93, 27);
            this.btnBrowsefile.TabIndex = 5;
            this.btnBrowsefile.Text = "Browse File";
            this.btnBrowsefile.UseVisualStyleBackColor = true;
            this.btnBrowsefile.Click += new System.EventHandler(this.btnBrowsefile_Click);
            // 
            // lblFilepath
            // 
            this.lblFilepath.AutoSize = true;
            this.lblFilepath.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFilepath.Location = new System.Drawing.Point(930, 139);
            this.lblFilepath.Name = "lblFilepath";
            this.lblFilepath.Size = new System.Drawing.Size(55, 19);
            this.lblFilepath.TabIndex = 5;
            this.lblFilepath.Text = "File ...";
            // 
            // lblPanelTitulo
            // 
            this.lblPanelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.lblPanelTitulo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblPanelTitulo.Location = new System.Drawing.Point(0, 14);
            this.lblPanelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPanelTitulo.Name = "lblPanelTitulo";
            this.lblPanelTitulo.Size = new System.Drawing.Size(4, 27);
            this.lblPanelTitulo.TabIndex = 5;
            this.lblPanelTitulo.Text = " ";
            this.lblPanelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblPanelTitulo);
            this.panel2.Controls.Add(this.lblModuleName);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 50);
            this.panel2.TabIndex = 8;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PIN";
            this.dataGridViewTextBoxColumn1.HeaderText = "PIN";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SerialNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "SerialNumber";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Password";
            this.dataGridViewTextBoxColumn4.HeaderText = "Password";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UserType";
            this.dataGridViewTextBoxColumn5.HeaderText = "UserType";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // rbAltaUsuarios
            // 
            this.rbAltaUsuarios.AutoSize = true;
            this.rbAltaUsuarios.Font = new System.Drawing.Font("Arial", 10F);
            this.rbAltaUsuarios.Location = new System.Drawing.Point(1087, 94);
            this.rbAltaUsuarios.Name = "rbAltaUsuarios";
            this.rbAltaUsuarios.Size = new System.Drawing.Size(116, 23);
            this.rbAltaUsuarios.TabIndex = 9;
            this.rbAltaUsuarios.TabStop = true;
            this.rbAltaUsuarios.Text = "Registration";
            this.rbAltaUsuarios.UseVisualStyleBackColor = true;
            this.rbAltaUsuarios.CheckedChanged += new System.EventHandler(this.rbAltaUsuarios_CheckedChanged);
            // 
            // rbBajaUsuarios
            // 
            this.rbBajaUsuarios.AutoSize = true;
            this.rbBajaUsuarios.Font = new System.Drawing.Font("Arial", 10F);
            this.rbBajaUsuarios.Location = new System.Drawing.Point(1239, 94);
            this.rbBajaUsuarios.Name = "rbBajaUsuarios";
            this.rbBajaUsuarios.Size = new System.Drawing.Size(121, 23);
            this.rbBajaUsuarios.TabIndex = 10;
            this.rbBajaUsuarios.TabStop = true;
            this.rbBajaUsuarios.Text = "Unsubscribe";
            this.rbBajaUsuarios.UseVisualStyleBackColor = true;
            this.rbBajaUsuarios.CheckedChanged += new System.EventHandler(this.rbBajaUsuarios_CheckedChanged);
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOperacion.Location = new System.Drawing.Point(930, 96);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(120, 19);
            this.lblOperacion.TabIndex = 11;
            this.lblOperacion.Text = "Operation Type";
            // 
            // lblTituloCarga
            // 
            this.lblTituloCarga.AutoSize = true;
            this.lblTituloCarga.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCarga.Location = new System.Drawing.Point(917, 62);
            this.lblTituloCarga.Name = "lblTituloCarga";
            this.lblTituloCarga.Size = new System.Drawing.Size(108, 19);
            this.lblTituloCarga.TabIndex = 12;
            this.lblTituloCarga.Text = "User loading";
            // 
            // lblTitulovalidacion
            // 
            this.lblTitulovalidacion.AutoSize = true;
            this.lblTitulovalidacion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulovalidacion.Location = new System.Drawing.Point(917, 242);
            this.lblTitulovalidacion.Name = "lblTitulovalidacion";
            this.lblTitulovalidacion.Size = new System.Drawing.Size(116, 19);
            this.lblTitulovalidacion.TabIndex = 13;
            this.lblTitulovalidacion.Text = "File validation";
            // 
            // lblSinError
            // 
            this.lblSinError.AutoSize = true;
            this.lblSinError.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinError.Location = new System.Drawing.Point(931, 315);
            this.lblSinError.Name = "lblSinError";
            this.lblSinError.Size = new System.Drawing.Size(254, 19);
            this.lblSinError.TabIndex = 14;
            this.lblSinError.Text = "The uploaded file has no errors";
            // 
            // UCBulkLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblSinError);
            this.Controls.Add(this.lblTitulovalidacion);
            this.Controls.Add(this.lblTituloCarga);
            this.Controls.Add(this.lblOperacion);
            this.Controls.Add(this.rbBajaUsuarios);
            this.Controls.Add(this.rbAltaUsuarios);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBrowsefile);
            this.Controls.Add(this.lblFilepath);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCBulkLoad";
            this.Size = new System.Drawing.Size(2349, 1174);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargaDatos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModuleName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFilepath;
        private System.Windows.Forms.Button btnBrowsefile;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblPanelTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dgvCargaDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.RadioButton rbAltaUsuarios;
        private System.Windows.Forms.RadioButton rbBajaUsuarios;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Label lblTituloCarga;
        private System.Windows.Forms.Label lblTitulovalidacion;
        private System.Windows.Forms.Label lblSinError;
        private System.Windows.Forms.Label lblTituloGrid;
    }
}
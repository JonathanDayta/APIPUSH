
namespace Attendance
{
    partial class UCMigrationLoad
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

        #region Component Designer generated code

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
            this.numEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.site = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desDepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPanelTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.lblTituloCarga = new System.Windows.Forms.Label();
            this.txtxSearchSite = new System.Windows.Forms.TextBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
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
            this.lblModuleName.Size = new System.Drawing.Size(141, 23);
            this.lblModuleName.TabIndex = 1;
            this.lblModuleName.Text = "Migration Load";
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
            this.lblTituloGrid.Size = new System.Drawing.Size(187, 19);
            this.lblTituloGrid.TabIndex = 1;
            this.lblTituloGrid.Text = "Employee to be loaded";
            // 
            // dgvCargaDatos
            // 
            this.dgvCargaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargaDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numEmpleado,
            this.nombre,
            this.site,
            this.desDepto});
            this.dgvCargaDatos.Location = new System.Drawing.Point(-1, 33);
            this.dgvCargaDatos.Name = "dgvCargaDatos";
            this.dgvCargaDatos.ReadOnly = true;
            this.dgvCargaDatos.RowHeadersWidth = 51;
            this.dgvCargaDatos.RowTemplate.Height = 24;
            this.dgvCargaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargaDatos.Size = new System.Drawing.Size(904, 705);
            this.dgvCargaDatos.TabIndex = 0;
            // 
            // numEmpleado
            // 
            this.numEmpleado.DataPropertyName = "numEmpleado";
            this.numEmpleado.HeaderText = "PIN";
            this.numEmpleado.MinimumWidth = 6;
            this.numEmpleado.Name = "numEmpleado";
            this.numEmpleado.ReadOnly = true;
            this.numEmpleado.Width = 125;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Name";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 125;
            // 
            // site
            // 
            this.site.DataPropertyName = "site";
            this.site.HeaderText = "Site";
            this.site.MinimumWidth = 6;
            this.site.Name = "site";
            this.site.ReadOnly = true;
            // 
            // desDepto
            // 
            this.desDepto.DataPropertyName = "desDepto";
            this.desDepto.HeaderText = "Department";
            this.desDepto.MinimumWidth = 6;
            this.desDepto.Name = "desDepto";
            this.desDepto.ReadOnly = true;
            this.desDepto.Width = 270;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1291, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 27);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOperacion.Location = new System.Drawing.Point(945, 97);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(37, 19);
            this.lblOperacion.TabIndex = 11;
            this.lblOperacion.Text = "Site";
            // 
            // lblTituloCarga
            // 
            this.lblTituloCarga.AutoSize = true;
            this.lblTituloCarga.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCarga.Location = new System.Drawing.Point(917, 62);
            this.lblTituloCarga.Name = "lblTituloCarga";
            this.lblTituloCarga.Size = new System.Drawing.Size(97, 19);
            this.lblTituloCarga.TabIndex = 12;
            this.lblTituloCarga.Text = "Site search";
            // 
            // txtxSearchSite
            // 
            this.txtxSearchSite.Location = new System.Drawing.Point(1004, 96);
            this.txtxSearchSite.Name = "txtxSearchSite";
            this.txtxSearchSite.Size = new System.Drawing.Size(251, 22);
            this.txtxSearchSite.TabIndex = 15;
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(946, 169);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(51, 17);
            this.lblDevice.TabIndex = 16;
            this.lblDevice.Text = "Device";
            // 
            // cmbDevice
            // 
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(1004, 166);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(251, 24);
            this.cmbDevice.TabIndex = 17;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1291, 160);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(123, 30);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.Text = "Load employees";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // UCMigrationLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.txtxSearchSite);
            this.Controls.Add(this.lblTituloCarga);
            this.Controls.Add(this.lblOperacion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCMigrationLoad";
            this.Size = new System.Drawing.Size(2349, 1174);
            this.Load += new System.EventHandler(this.UCMigrationLoad_Load);
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPanelTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dgvCargaDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn numEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn site;
        private System.Windows.Forms.DataGridViewTextBoxColumn desDepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Label lblTituloCarga;
        private System.Windows.Forms.Label lblTituloGrid;
        private System.Windows.Forms.TextBox txtxSearchSite;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Button btnLoad;
    }
}

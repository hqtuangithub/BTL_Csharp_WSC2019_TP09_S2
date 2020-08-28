namespace GUI
{
    partial class frmMaintenance
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
            this.btnManage = new System.Windows.Forms.Button();
            this.dgvAssetRequest = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManage
            // 
            this.btnManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.Location = new System.Drawing.Point(37, 431);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(372, 32);
            this.btnManage.TabIndex = 5;
            this.btnManage.Text = "Manage Request";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // dgvAssetRequest
            // 
            this.dgvAssetRequest.AllowUserToAddRows = false;
            this.dgvAssetRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssetRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvAssetRequest.Location = new System.Drawing.Point(37, 78);
            this.dgvAssetRequest.Name = "dgvAssetRequest";
            this.dgvAssetRequest.ReadOnly = true;
            this.dgvAssetRequest.Size = new System.Drawing.Size(813, 332);
            this.dgvAssetRequest.TabIndex = 4;
            this.dgvAssetRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssetRequest_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of Assets Requesting EM:";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "AssetSN";
            this.Column1.HeaderText = "Asset SN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 128;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "AssetName";
            this.Column2.HeaderText = "Asset Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 129;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RequestDate";
            this.Column3.HeaderText = "Request Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 128;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "EmployeeFullName";
            this.Column4.HeaderText = "Employee Full Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 128;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Department";
            this.Column5.HeaderText = "Department";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 129;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Name";
            this.Column6.HeaderText = "Priorities Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.dgvAssetRequest);
            this.Controls.Add(this.label1);
            this.Name = "frmMaintenance";
            this.Text = "Emergency Maintenance Managment";
            this.Load += new System.EventHandler(this.frmMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.DataGridView dgvAssetRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
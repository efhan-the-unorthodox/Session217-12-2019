namespace Session217_12_2019
{
    partial class MMmanagement
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
            this.manageRequest = new System.Windows.Forms.Button();
            this.maintenanceRequeststable = new System.Windows.Forms.DataGridView();
            this.AssetSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmplyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceRequeststable)).BeginInit();
            this.SuspendLayout();
            // 
            // manageRequest
            // 
            this.manageRequest.Location = new System.Drawing.Point(15, 455);
            this.manageRequest.Name = "manageRequest";
            this.manageRequest.Size = new System.Drawing.Size(249, 30);
            this.manageRequest.TabIndex = 5;
            this.manageRequest.Text = "Manage Request";
            this.manageRequest.UseVisualStyleBackColor = true;
            this.manageRequest.Click += new System.EventHandler(this.manageRequest_Click);
            // 
            // maintenanceRequeststable
            // 
            this.maintenanceRequeststable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.maintenanceRequeststable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.maintenanceRequeststable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssetSN,
            this.AssetName,
            this.RequestDate,
            this.EmplyName,
            this.Dept,
            this.EMRequestID});
            this.maintenanceRequeststable.Location = new System.Drawing.Point(12, 43);
            this.maintenanceRequeststable.Name = "maintenanceRequeststable";
            this.maintenanceRequeststable.RowHeadersWidth = 51;
            this.maintenanceRequeststable.RowTemplate.Height = 24;
            this.maintenanceRequeststable.Size = new System.Drawing.Size(858, 406);
            this.maintenanceRequeststable.TabIndex = 4;
            // 
            // AssetSN
            // 
            this.AssetSN.HeaderText = "Asset SN";
            this.AssetSN.MinimumWidth = 6;
            this.AssetSN.Name = "AssetSN";
            // 
            // AssetName
            // 
            this.AssetName.HeaderText = "Asset Name";
            this.AssetName.MinimumWidth = 6;
            this.AssetName.Name = "AssetName";
            // 
            // RequestDate
            // 
            this.RequestDate.HeaderText = "Request Date";
            this.RequestDate.MinimumWidth = 6;
            this.RequestDate.Name = "RequestDate";
            // 
            // EmplyName
            // 
            this.EmplyName.HeaderText = "Employee Full Name";
            this.EmplyName.MinimumWidth = 6;
            this.EmplyName.Name = "EmplyName";
            // 
            // Dept
            // 
            this.Dept.HeaderText = "Department";
            this.Dept.MinimumWidth = 6;
            this.Dept.Name = "Dept";
            // 
            // EMRequestID
            // 
            this.EMRequestID.HeaderText = "Request ID";
            this.EMRequestID.MinimumWidth = 6;
            this.EMRequestID.Name = "EMRequestID";
            this.EMRequestID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of assets requesting Emergency Maintenance:\r\n";
            // 
            // MMmanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 497);
            this.Controls.Add(this.manageRequest);
            this.Controls.Add(this.maintenanceRequeststable);
            this.Controls.Add(this.label1);
            this.Name = "MMmanagement";
            this.Text = "Emergency Maintenance Management";
            this.Load += new System.EventHandler(this.MMmanagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceRequeststable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button manageRequest;
        private System.Windows.Forms.DataGridView maintenanceRequeststable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmplyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMRequestID;
    }
}
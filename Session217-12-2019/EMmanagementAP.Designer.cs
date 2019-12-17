namespace Session217_12_2019
{
    partial class EMmanagementAP
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
            this.label1 = new System.Windows.Forms.Label();
            this.assetTable = new System.Windows.Forms.DataGridView();
            this.AssetSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastClosedEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.assetTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Assets";
            // 
            // assetTable
            // 
            this.assetTable.AllowUserToAddRows = false;
            this.assetTable.AllowUserToDeleteRows = false;
            this.assetTable.AllowUserToOrderColumns = true;
            this.assetTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assetTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssetSN,
            this.AssetName,
            this.LastClosedEM,
            this.EMCount,
            this.AssetID});
            this.assetTable.Location = new System.Drawing.Point(12, 50);
            this.assetTable.Name = "assetTable";
            this.assetTable.ReadOnly = true;
            this.assetTable.RowHeadersWidth = 51;
            this.assetTable.RowTemplate.Height = 24;
            this.assetTable.Size = new System.Drawing.Size(858, 406);
            this.assetTable.TabIndex = 1;
            this.assetTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.assetTable_CellFormatting);
            // 
            // AssetSN
            // 
            this.AssetSN.HeaderText = "Asset SN";
            this.AssetSN.MinimumWidth = 6;
            this.AssetSN.Name = "AssetSN";
            this.AssetSN.ReadOnly = true;
            // 
            // AssetName
            // 
            this.AssetName.HeaderText = "Asset name";
            this.AssetName.MinimumWidth = 6;
            this.AssetName.Name = "AssetName";
            this.AssetName.ReadOnly = true;
            // 
            // LastClosedEM
            // 
            this.LastClosedEM.HeaderText = "Last Closed EM";
            this.LastClosedEM.MinimumWidth = 6;
            this.LastClosedEM.Name = "LastClosedEM";
            this.LastClosedEM.ReadOnly = true;
            // 
            // EMCount
            // 
            this.EMCount.HeaderText = "Number of EMs";
            this.EMCount.MinimumWidth = 6;
            this.EMCount.Name = "EMCount";
            this.EMCount.ReadOnly = true;
            // 
            // AssetID
            // 
            this.AssetID.HeaderText = "AssetID";
            this.AssetID.MinimumWidth = 6;
            this.AssetID.Name = "AssetID";
            this.AssetID.ReadOnly = true;
            this.AssetID.Visible = false;
            // 
            // sendRequest
            // 
            this.sendRequest.Location = new System.Drawing.Point(31, 466);
            this.sendRequest.Name = "sendRequest";
            this.sendRequest.Size = new System.Drawing.Size(302, 23);
            this.sendRequest.TabIndex = 2;
            this.sendRequest.Text = "Send Emergency Maintenance Request";
            this.sendRequest.UseVisualStyleBackColor = true;
            this.sendRequest.Click += new System.EventHandler(this.sendRequest_Click);
            // 
            // EMmanagementAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 497);
            this.Controls.Add(this.sendRequest);
            this.Controls.Add(this.assetTable);
            this.Controls.Add(this.label1);
            this.Name = "EMmanagementAP";
            this.Text = "Emergency Maintenance Management";
            this.Load += new System.EventHandler(this.EMmanagementAP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView assetTable;
        private System.Windows.Forms.Button sendRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastClosedEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetID;
    }
}
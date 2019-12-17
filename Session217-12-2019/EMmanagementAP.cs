using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session217_12_2019
{
    public partial class EMmanagementAP : Form
    {
        public long AID;
        public long UID;
        public EMmanagementAP()
        {
            InitializeComponent();

        }

        private void EMmanagementAP_Load(object sender, EventArgs e)
        {
            this.loadAssetstable(sender, e);
        }

        private void loadAssetstable(object sender, EventArgs e)
        {
            UID = GV.userID;
            assetTable.Rows.Clear();
            using (Session2Entities db = new Session2Entities())
            {
                var getAssets = db.Assets.Where(a => a.EmployeeID == UID).ToList();
                foreach (var item in getAssets)
                {
                    AID = item.ID;
                    object[] row = new object[5];
                    var lastClosedEm = (from em in db.EmergencyMaintenances
                                        where em.AssetID == AID
                                        orderby em.EMEndDate descending
                                        select new
                                        {
                                            em.EMEndDate
                                        }).FirstOrDefault();
                    if(lastClosedEm == null)
                    {
                        row[2] = "";
                    }
                    else
                    {
                        row[2] = lastClosedEm.EMEndDate;
                    }                    
                    row[0] = item.AssetSN;
                    row[1] = item.AssetName;
                    row[3] = db.EmergencyMaintenances.Where(a => a.AssetID == AID && a.EMEndDate != null).Count();
                    row[4] = AID;

                    assetTable.Rows.Add(row);
                }
            }
        }

        private void assetTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow row in assetTable.Rows)
            {
                var lastClosedEm = row.Cells[2].Value;
                if(lastClosedEm == "")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void sendRequest_Click(object sender, EventArgs e)
        {
            var assetID = assetTable.CurrentRow.Cells[4].Value;
            
            EMRequestAP emrequestform = new EMRequestAP(Convert.ToInt64(assetID));
            emrequestform.refreshform += new EventHandler(loadAssetstable);
            emrequestform.ShowDialog();
        }
    }
}

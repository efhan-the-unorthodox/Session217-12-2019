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
    public partial class EMRequestAP : Form
    {

        public EventHandler refreshform;
        public long AID;
        public Dictionary<long, string> priorities;
        public EMRequestAP(long assetID)
        {
            InitializeComponent();
            AID = new long();
            AID = assetID;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EMRequestAP_Load(object sender, EventArgs e)
        {
            loadAssetdetails(sender, e);
            loadprioritybox(sender, e);
        }
        private void loadAssetdetails(object sender, EventArgs e)
        {
            using(Session2Entities db = new Session2Entities())
            {
                var getdetails = db.Assets.Where(a => a.ID == AID);
                label8.Text = getdetails.FirstOrDefault().DepartmentLocation.Department.Name.ToString();
                label7.Text = getdetails.FirstOrDefault().AssetName;
                label6.Text = getdetails.FirstOrDefault().AssetSN;
            }
        }
        private void loadprioritybox(object sender, EventArgs e)
        {
            using(Session2Entities db = new Session2Entities())
            {
                //getting  priorities
                var getp = from p in db.Priorities
                           orderby p.ID ascending
                           select new
                           {
                               p
                           };
                priorities = new Dictionary<long, string>();
                foreach(var item in getp)
                {
                    var pid = item.p.ID;
                    var pName = item.p.Name;
                    priorities.Add(pid, pName);
                }

                prioritybox.DataSource = new BindingSource(priorities, null);
                prioritybox.DisplayMember = "Value";
                prioritybox.ValueMember = "Key";
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            refreshform(sender, e);
            this.Close();
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if(emDescription.Text.Length == 0)
            {
                validationlabel.Text = "Empty Emergency Description";
                validationlabel.Show();
            }
            else if(emOthers.Text.Length == 0)
            {
                validationlabel1.Text = "Other details are empty. If there are none, enter 'None' ";
                validationlabel1.Show();
            }
            else
            {
                newEMrequest(sender, e);
                refreshform(sender, e);
                this.Close();
            }
        }
        //method to add new EM Request
        private void newEMrequest(object sender, EventArgs e)
        {
            string emergencydescription = emDescription.Text;
            string otherconsiderations = emOthers.Text;

            EmergencyMaintenance newEM = new EmergencyMaintenance();
            long pid = ((KeyValuePair<long, string>)prioritybox.SelectedItem).Key;
            newEM.AssetID = AID;
            newEM.PriorityID = pid;
            newEM.DescriptionEmergency = emergencydescription;
            newEM.OtherConsiderations = otherconsiderations;
            newEM.EMReportDate = DateTime.Now.Date;
            newEM.EMStartDate = DateTime.Now.Date;
            newEM.EMEndDate = null;
            //newEM.EMTechnicianNote = null;
            using(Session2Entities db = new Session2Entities())
            {
                db.EmergencyMaintenances.Add(newEM);
                db.SaveChanges();
            }
        }
    }
}

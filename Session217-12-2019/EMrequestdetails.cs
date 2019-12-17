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
    public partial class EMrequestdetails : Form
    {
        public long EMID;
        public long AID;
        public Dictionary<long, string> partsKvp;
        public List<ChangedPart> currentList = new List<ChangedPart>();
        public List<parts> newList;

        public EventHandler refreshForm;

        public class parts
        {

            public long partid { get; set; }
            public string partname { get; set; }
            public decimal amount { get; set; }
        }
        public EMrequestdetails(long maintenancerequestid)
        {
            InitializeComponent();
            EMID = new long();
            EMID = maintenancerequestid;
        }

        private void EMrequestdetails_Load(object sender, EventArgs e)
        {
            loadAssetdetails(sender, e);
            loadPartslist(sender, e);
            getExistingparts(sender, e);
        }
        private void loadAssetdetails(object sender, EventArgs e)
        {
            using (Session2Entities db = new Session2Entities())
            {
                var getmaintenancedetails = db.EmergencyMaintenances.Where(em => em.ID == EMID).FirstOrDefault();
                AID = getmaintenancedetails.AssetID;
                var getassetdetails = db.Assets.Where(a => a.ID == AID).FirstOrDefault();
                label6.Text = getassetdetails.AssetSN;
                label7.Text = getassetdetails.AssetName;
                label8.Text = getassetdetails.DepartmentLocation.Department.Name;
                startdatepicker.Value = Convert.ToDateTime(getmaintenancedetails.EMStartDate).Date;
            }
        }
        private void loadPartslist(object sender, EventArgs e)
        {
            partsKvp = new Dictionary<long, string>();
            using (Session2Entities db = new Session2Entities())
            {
                var partsList = db.Parts;
                foreach (var item in partsList)
                {
                    var pid = item.ID;
                    var pname = item.Name;
                    partsKvp.Add(pid, pname);
                }
                partscombobox.DataSource = new BindingSource(partsKvp, null);
                partscombobox.DisplayMember = "Value";
                partscombobox.ValueMember = "Key";
            }
        }
        private void getExistingparts(object sender, EventArgs e)
        {
            using (Session2Entities db = new Session2Entities())
            {
                //getting existing changed parts
                var getParts = db.ChangedParts.Where(p => p.EmergencyMaintenanceID == EMID).ToList();
                if (getParts != null)
                {
                    newList = new List<parts>();
                    foreach (var item in getParts)
                    {
                        parts p = new parts();
                        p.partid = item.PartID;
                        p.amount = item.Amount;
                        p.partname = item.Part.Name;

                        newList.Add(p);
                        currentList.Add(item);
                    }
                    loadchangedParts(sender, e);
                }
            }
        }
        private void loadchangedParts(object sender, EventArgs e)
        {
            changedPartstable.Rows.Clear();
            foreach (var p in newList)
            {
                object[] row = new object[4];
                row[0] = p.partname;
                row[1] = p.amount;
                row[2] = "Remove";
                row[3] = p.partid;
                changedPartstable.Rows.Add(row);
            }
        }

        private void changedPartstable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var partindex = e.RowIndex;
                newList.RemoveAt(partindex);
                this.loadchangedParts(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyValuePair<long, string> selectedPart = ((KeyValuePair<long, string>)partscombobox.SelectedItem);
            decimal amount = numericUpDown1.Value;
            if (amount == 0)
            {
                MessageBox.Show("Please give a valid amount");
            }
            else
            {
                parts addpart = new parts();
                addpart.partid = selectedPart.Key;
                addpart.partname = selectedPart.Value;
                addpart.amount = amount;
                newList.Add(addpart);
                loadchangedParts(sender, e);
            }
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            if (techniciannote.Text == "")
            {
                MessageBox.Show("Enter valid technician details");
            }
            else if (startdatepicker.Value > enddatepicker.Value)
            {
                MessageBox.Show("End date cannot be before start date");
            }
            else
            {
                //getting technician note
                string techNote = techniciannote.Text;

                //getting EMstartdate and EMenddate
                var EMstartdate = Convert.ToDateTime(startdatepicker.Value).Date;
                var EMenddate = Convert.ToDateTime(enddatepicker.Value).Date;


                //saving changes to the list of changed parts by overwrting to the list
                using (Session2Entities db = new Session2Entities())
                {
                    var emreq = db.EmergencyMaintenances.Where(em => em.ID == EMID).FirstOrDefault();
                    emreq.EMEndDate = EMenddate;
                    emreq.EMStartDate = EMstartdate;
                    emreq.EMReportDate = EMstartdate;
                    emreq.EMTechnicianNote = techNote;


                    var listofexistingparts = db.ChangedParts.Where(cp => cp.EmergencyMaintenanceID == EMID);

                    foreach (var existingpart in listofexistingparts)
                    {
                        db.ChangedParts.Remove(existingpart);

                    }
                    foreach (var newPart in newList)
                    {
                        ChangedPart np = new ChangedPart();
                        np.EmergencyMaintenanceID = EMID;
                        np.PartID = newPart.partid;
                        np.Amount = newPart.amount;
                        db.ChangedParts.Add(np);
                    }

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Changes saved");
                        refreshForm(sender, e);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("an error has occurred. Details: " + ex.Message);
                        
                    }
                   
                }

            }

        }
    }
}

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
    public partial class MMmanagement : Form
    {
        public long UID;
        public long EMID;
        public MMmanagement()
        {
            InitializeComponent();
            UID = GV.userID;
        }

        private void MMmanagement_Load(object sender, EventArgs e)
        {
            loadmaintenancerequests(sender, e);
        }
        private void loadmaintenancerequests(object sender, EventArgs e)
        {
            //load all emergency maintenance requests
            maintenanceRequeststable.Rows.Clear();
            using(Session2Entities db = new Session2Entities())
            {
                var emrequests = db.EmergencyMaintenances.ToList();
                foreach(var item in emrequests)
                {
                    var employeeID = item.Asset.EmployeeID;
                    var employeedetails = db.Employees.Where(emp => emp.ID == employeeID).FirstOrDefault();

                    string employeefullname = employeedetails.FirstName + " " + employeedetails.LastName;

                    object[] row = new object[6];
                    row[0] = item.Asset.AssetSN;
                    row[1] = item.Asset.AssetName;
                    row[2] = item.EMReportDate.ToString("yyyy-MM-dd");
                    row[3] = employeefullname;
                    row[4] = item.Asset.DepartmentLocation.Department.Name;
                    row[5] = item.ID;

                    maintenanceRequeststable.Rows.Add(row);
                }
            }
        }

        private void manageRequest_Click(object sender, EventArgs e)
        {
            EMID = new long();
            var maintenanceid = maintenanceRequeststable.CurrentRow.Cells[5].Value;
            EMID = (long)maintenanceid;
            EMrequestdetails newRequest = new EMrequestdetails(EMID);
            EventHandler refreshform = new EventHandler(loadmaintenancerequests);
            newRequest.refreshForm += refreshform;
            newRequest.ShowDialog();
        }
    }
}

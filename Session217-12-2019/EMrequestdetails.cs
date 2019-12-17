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
        public EMrequestdetails(long maintenancerequestid)
        {
            InitializeComponent();
            EMID = new long();
            EMID = maintenancerequestid;
        }

        private void EMrequestdetails_Load(object sender, EventArgs e)
        {

        }
    }
}

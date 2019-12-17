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
    public partial class Form1 : Form
    {

        public string username;
        public string password;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            username = this.usernamebox.Text;
            password = this.passwordbox.Text;

            using (Session2Entities db = new Session2Entities())
            {
                var getUserdetails = (from a in db.Employees
                                      where a.Username.Equals(username)
                                      select new
                                      {
                                          a
                                      }).FirstOrDefault();

                if (getUserdetails == null)
                {
                    MessageBox.Show("Invalid Username");
                }
                else
                {
                    if (getUserdetails.a.Password.Equals(password))
                    {
                        var  isAdmin = getUserdetails.a.isAdmin;
                        if (isAdmin == true)
                        {
                            GV.isAdmin = true;
                            GV.userID = getUserdetails.a.ID;
                            MMmanagement mmForm = new MMmanagement();
                            this.Hide();
                            mmForm.ShowDialog();
                            Close();
                        }
                        else if (isAdmin == null)
                        {
                            GV.isAdmin = false;
                            GV.userID = getUserdetails.a.ID;
                            EMmanagementAP apform = new EMmanagementAP();
                            this.Hide();
                            apform.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }
                }
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

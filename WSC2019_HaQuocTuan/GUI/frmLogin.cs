using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using BULs;
namespace GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string username;

        public string Username { get => username; set => username = value; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Username = txtUsername.Text;
            EmployeesBUL employeesBUL = new EmployeesBUL();
            if (employeesBUL.EmployeeLogin(txtUsername.Text, txtPassword.Text) == true)
            {
                if (employeesBUL.IsAdminLogin(txtUsername.Text, txtPassword.Text) == true)
                {
                    frmMaintenance maintenance = new frmMaintenance();
                    this.Hide();
                    maintenance.ShowDialog();
                    txtPassword.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                    this.Show();
                }
                else
                {
                    
                    frmEmployee employee = new frmEmployee(this.Username);
                    this.Hide();
                    employee.ShowDialog();
                    txtPassword.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                    this.Show();
                }
            }
            else
                MessageBox.Show("The account or password you entered is incorrect !","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit ?", "EXIT", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                this.Close();
        }

       
    }
}

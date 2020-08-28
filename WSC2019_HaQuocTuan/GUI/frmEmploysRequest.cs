using System;
using System.CodeDom.Compiler;
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
    public partial class frmEmploysRequest : Form
    {
        string assetName;
        string assetSN;
        public string AssetName { get => assetName; set => assetName = value; }
        public string AssetSN { get => assetSN; set => assetSN = value; }

        public frmEmploysRequest()
        {
            InitializeComponent();
        }

        //constructor để gán dữ liệu, để đổ lại vào form
        public frmEmploysRequest(string assetsn, string assetname)
        {
            InitializeComponent();
            this.AssetName = assetname;
            this.AssetSN = assetsn;
        }

        private void frmEmploysRequest_Load(object sender, EventArgs e)
        {
            txtAssetSN.Text = this.AssetSN;
            txtAssetName.Text = this.AssetName;

            //Hiển thị Department theo Asset được chọn
            AssetsBUL assets = new AssetsBUL();
            txtDepartment.Text = assets.DepartmentRequest(txtAssetName.Text);

            //Hiển thị cbb Priorities
            PrioritiesBUL priorities = new PrioritiesBUL();
            cbbPriorities.DataSource = priorities.PrioritiyShow();
            cbbPriorities.DisplayMember = "Name";
            cbbPriorities.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmergenceMaintenanceBUL em = new EmergenceMaintenanceBUL();
            int assetID = em.getEmergencyMaintenanceID(txtAssetSN.Text, txtAssetName.Text);

            try
            {
                em.InsertEM(assetID, Convert.ToInt32(cbbPriorities.SelectedValue), txtDescription.Text, txtOtherConsideration.Text);
                MessageBox.Show("Done !");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Exception");
            }

        }
    }
}

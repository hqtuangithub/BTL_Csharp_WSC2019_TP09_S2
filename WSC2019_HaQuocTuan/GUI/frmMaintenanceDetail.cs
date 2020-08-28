using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;

namespace GUI
{
    public partial class frmMaintenanceDetail : Form
    {
        public frmMaintenanceDetail()
        {
            InitializeComponent();
        }
        string assetName;
        string assetSN;
        DateTime requestDay;
        public string AssetName { get => assetName; set => assetName = value; }
        public string AssetSN { get => assetSN; set => assetSN = value; }
        public DateTime RequestDay { get => requestDay; set => requestDay = value; }

        public frmMaintenanceDetail(string assetsn, string assetname, DateTime requestDay)
        {
            InitializeComponent();
            this.AssetName = assetname;
            this.AssetSN = assetsn;
            this.RequestDay = requestDay;
        }
        private bool dateChanged = false;

        #region Load form
        private void frmMaintenanceDetail_Load(object sender, EventArgs e)
        {
            txtAssetSN.Text = this.AssetSN;
            txtAssetName.Text = this.AssetName;
            //Hiển thị Department theo Asset được chọn
            AssetsBUL assets = new AssetsBUL();
            txtDepartment.Text = assets.DepartmentRequest(txtAssetName.Text);
            //cbb Part Name
            PartsBUL parts = new PartsBUL();
            cbbPartName.DataSource = parts.PartShow();
            cbbPartName.DisplayMember = "Name";
            cbbPartName.ValueMember = "ID";

            //danh sach Parts of Asset
            dgvParts.DataSource = parts.PartOfAsset(txtAssetName.Text, this.RequestDay);

            //reset thời gian
            dtpStartDate.Value = DateTime.Today;
            dtpCompleted.Value = DateTime.Today;

        }
        #endregion

        #region Asset EM Report
        //start date
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

            if (dtpStartDate.Value < this.RequestDay)
            {
                MessageBox.Show("Ngày bắt đầu phải sau ngày Request", "Không hợp lệ", MessageBoxButtons.OK);
                dtpStartDate.Value = DateTime.Today;
            }

            
        }

        private void dtpStartDate_DropDown(object sender, EventArgs e)
        {
            dateChanged = true;
        }
        //completed


        private void dtpCompleted_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                MessageBox.Show("Chưa nhập Technician Note", "Thông báo", MessageBoxButtons.OK);
                txtNote.Focus();
                //dtpCompleted.AllowDrop = false;
            }
            else
            {
                dtpStartDate.Enabled = false;
                txtNote.Enabled = false;
                cbbPartName.Enabled = false;
                txtAmount.Enabled = false;
                btnAdd.Enabled = false;
                dgvParts.Enabled = false;
            }    
            //sau khi thêm ngày hoàn thành, không thể thực hiện thêm thao tác nào khác
            
        }
        #endregion

        #region Replacement Parts
        //button: add to list
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //parts được chọn chưa hết hạn
            PartsBUL parts = new PartsBUL();
            if (parts.CheckParts(Convert.ToInt32(cbbPartName.SelectedValue), this.AssetName, this.RequestDay) == false)
                MessageBox.Show("Sản phẩm đã có hoặc còn hạn sử dụng"); //note: thêm Effective trong thông báo
            else
            {
                if (string.IsNullOrEmpty(txtAmount.Text) == true)
                {
                    txtAmount.Focus();
                    MessageBox.Show("Chưa nhập Amount");
                }
                else
                {
                    PartsBUL partsBUL = new PartsBUL();
                    //Lấy EmergencyMaintenanceID
                    int EMID = partsBUL.getEmergencyMaintenanceID(txtAssetName.Text, this.RequestDay);
                    int partID = Convert.ToInt32(cbbPartName.SelectedValue);
                    decimal amount = Convert.ToDecimal(txtAmount.Text);

                    //add to list, insert query
                    partsBUL.AddToList(EMID, partID, amount);

                    //load lại datagridview
                    dgvParts.DataSource = partsBUL.PartOfAsset(txtAssetName.Text, this.RequestDay);

                    txtAmount.Clear();
                }    
                
            }
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmount, "Chưa nhập số lượng");
                txtAmount.Focus();
            }
            else
                e.Cancel = false;
        }

        //REMOVE
        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                PartsBUL partsBUL = new PartsBUL();
                string aNname = dgvParts.Rows[e.RowIndex].Cells["Column1"].Value.ToString();

                int EMID = partsBUL.getEmergencyMaintenanceID(txtAssetName.Text, this.RequestDay);

                partsBUL.DeleteFromList(EMID, aNname);

                //load lại datagridview
                dgvParts.DataSource = partsBUL.PartOfAsset(txtAssetName.Text, this.RequestDay);

            }
        }

        //CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //SUBMIT 
        //Khi ngày hoàn thành cho yêu cầu được đặt, 
        //người quản lý sẽ không thể thực hiện bất kỳ thay đổi nào đối với yêu cầu.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(dateChanged == false)
            {
                MessageBox.Show("Chưa thiết lập EM Start Date");
            }
            else
            {
                dtpStartDate.Enabled = false;
                dtpCompleted.Enabled = false;
                txtNote.Enabled = false;
                cbbPartName.Enabled = false;
                txtAmount.Enabled = false;
                btnAdd.Enabled = false;
                dgvParts.Enabled = false;

                PartsBUL partsBUL = new PartsBUL();
                int EMID = partsBUL.getEmergencyMaintenanceID(txtAssetName.Text, this.RequestDay);
                partsBUL.SubmitEM(dtpStartDate.Value, dtpCompleted.Value, txtNote.Text,EMID);
            }

        }





        #endregion

        
    }
}

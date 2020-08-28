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
using DTOs;

namespace GUI
{
    public partial class frmEmployee : Form
    {

        string username;
        public string Username { get => username; set => username = value; }
        public frmEmployee()
        {
            InitializeComponent();
        }
        public frmEmployee(string username)
        {
            InitializeComponent();
            this.Username = username;
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ListAvailableAssetBUL list = new ListAvailableAssetBUL();
            dgvAvailableAsset.DataSource = list.ShowAvailableAsset(this.Username);
            //định dạng lại ngày tháng
            dgvAvailableAsset.Columns["Column3"].DefaultCellStyle.Format = "Custom";
            dgvAvailableAsset.Columns["Column3"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        //đổi màu của tài sản chưa hoàn thành
        private void dgvAvailableAsset_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvAvailableAsset.Rows[e.RowIndex].Cells[2].Value == "")
            {
                dgvAvailableAsset.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }


        
        private void btnSend_Click(object sender, EventArgs e)
        {
            //khởi tạo form dùng constructor
            frmEmploysRequest employsRequest = new frmEmploysRequest(this.AssetSN, this.AssetName);
            this.Hide();
            employsRequest.ShowDialog();
            this.Show();


        }

        string assetName;
        string assetSN;

        public string AssetName { get => assetName; set => assetName = value; }
        public string AssetSN { get => assetSN; set => assetSN = value; }
        

        //gán giá trị khi click cho biến
        private void dgvAvailableAsset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.AssetName = dgvAvailableAsset.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.AssetSN = dgvAvailableAsset.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}

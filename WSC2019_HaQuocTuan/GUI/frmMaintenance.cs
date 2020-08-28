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
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            ListAssetRequestBUL listAssetRequest = new ListAssetRequestBUL();
            dgvAssetRequest.DataSource = listAssetRequest.AssetRequestShow();
            //định dạng lại ngày tháng
            dgvAssetRequest.Columns["Column3"].DefaultCellStyle.Format = "Custom";
            dgvAssetRequest.Columns["Column3"].DefaultCellStyle.Format = "yyyy-MM-dd";

            //
            btnManage.Enabled = false;

        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            
            frmMaintenanceDetail f = new frmMaintenanceDetail(this.AssetSN, this.AssetName, this.RequestDay);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        string assetName;
        string assetSN;
        DateTime requestDay;

        public string AssetName { get => assetName; set => assetName = value; }
        public string AssetSN { get => assetSN; set => assetSN = value; }
        public DateTime RequestDay { get => requestDay; set => requestDay = value; }


        //gán giá trị khi click cho biến
        private void dgvAssetRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                btnManage.Enabled = true;
                this.AssetName = dgvAssetRequest.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.AssetSN = dgvAssetRequest.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.RequestDay = Convert.ToDateTime(dgvAssetRequest.Rows[e.RowIndex].Cells[2].Value);
            }
        }
        

    }
}

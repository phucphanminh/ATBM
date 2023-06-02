using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH2
{
    public partial class NhanSu_Them_NhanVien : Form
    {
        public NhanSu_Them_NhanVien()
        {
            InitializeComponent();
        }

        private void bntThemMoi_Click(object sender, EventArgs e)
        {
            int check = txtDC.Text.Length * txtGT.Text.Length * txtHoTen.Text.Length * txtMANV.Text.Length * txtMAPB.Text.Length * txtNS.Text.Length * txtNVQL.Text.Length * txtSDT.Text.Length * txtVT.Text.Length;
            if(check == 0)
            {
                MessageBox.Show("Vui Lòng Nhập Đủ Thông Tin");
                return;
            }
            string query_string = string.Format("insert into GROUP08.NS_XemThongTin_NV values('{0}','{1}','{2}',to_date('{3}','mm/dd/yyyy'),'{4}','{5}',null,null,'{6}','{7}','{8}')",
                txtMANV.Text, txtHoTen.Text, txtGT.Text, txtNS.Text, txtDC.Text, txtSDT.Text, txtVT.Text, txtNVQL.Text, txtMAPB.Text);

            OracleConnection con = MyConnect.GetConn();
            con.Open();
            try
            {
                OracleCommand cmd = new OracleCommand(query_string, con);
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi thêm mới " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            con.Close();
            MessageBox.Show("Thêm Thành Công", "success");
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

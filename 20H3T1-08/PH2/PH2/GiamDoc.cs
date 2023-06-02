using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PH2
{
    public partial class GiamDoc : Form
    {
        public GiamDoc()
        {
            InitializeComponent();
            InitThongTinCaNhan();
        }
        
        private void InitThongTinCaNhan()
        {
            string query_sentence_1 = "select * from GROUP08.xemthongtincanhan where MANV = SYS_CONTEXT ('USERENV', 'SESSION_USER')";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1,MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            DataGridTable.DataSource = Table;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "select *from GROUP08.qlnv_nhanvien";
            labelTable.Text = "Danh Sách Nhân Viên";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            DataGridTable.DataSource = Table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "select *from GROUP08.qlnv_dean";
            labelTable.Text = "Danh Sách Đề Án";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            DataGridTable.DataSource = Table;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bntDSPC_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "select *from GROUP08.qlnv_phancong";
            labelTable.Text = "Danh Sách Phân Công";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            DataGridTable.DataSource = Table;
        }

        private void bntDSPB_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "select *from GROUP08.qlnv_phongban";
            labelTable.Text = "Danh Sách Phòng Ban";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            DataGridTable.DataSource = Table;
        }

        private void bntCapNhatTTCaNhan_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "update GROUP08.xemthongtincanhan set ";
            if (txtSDT.Text == "" && txtNgaySinh.Text == "" && txtDiaChi.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
            }
            else
            {
                if(txtSDT.Text != "")
                {
                    query_sentence_1 += " sodt = '" + txtSDT.Text + "',";
                }
                if (txtNgaySinh.Text != "")
                {
                    query_sentence_1 += " ngaysinh = to_date('" + txtNgaySinh.Text + "','mm/dd/yyyy'),";
                }
                if (txtDiaChi.Text != "")
                {
                    query_sentence_1 += " diachi = '" + txtDiaChi.Text + "'";
                }
            }
            if (query_sentence_1.Last() == ',')
            {
                query_sentence_1 = query_sentence_1.Remove(query_sentence_1.Length - 1, 1);
            }
            OracleConnection con = MyConnect.GetConn();
            con.Open();
            try
            {
                OracleCommand cmd = new OracleCommand(query_sentence_1, con);
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Cập Nhật" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            MessageBox.Show("Cập Nhật Thành Công", "success");
            InitThongTinCaNhan();
            Console.WriteLine(query_sentence_1);
        }
    }
}



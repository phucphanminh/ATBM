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
    public partial class QLTrucTiep : Form
    {
        public QLTrucTiep()
        {
            InitializeComponent();
            InitThongTinCaNhan();
        }

        private void InitThongTinCaNhan()
        {
            labelTable.Text = "Thông Tin Cá Nhân";
            string query_sentence_1 = "select * from GROUP08.xemthongtincanhan";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitThongTinCaNhan();
        }

        private void bntCapNhat_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "update GROUP08.xemthongtincanhan set ";
            if (txtSDT.Text == "" && txtNgaySinh.Text == "" && txtDiaChi.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
            }
            else
            {
                if (txtSDT.Text != "")
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
                return;
            }
            con.Close();
            MessageBox.Show("Cập Nhật Thành Công", "success");
            InitThongTinCaNhan();
            Console.WriteLine(query_sentence_1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Phòng Ban";
            string query_sentence_1 = "select * from GROUP08.QLNV_PHONGBAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void btnXemDSDeAn_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Đề Án";
            string query_sentence_1 = "select * from GROUP08.QLNV_DEAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Phân Công";
            string query_sentence_1 = "select * from GROUP08.NVQL_Xem_PC";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Nhân Viên Quản Lý";
            string query_sentence_1 = "select * from GROUP08.NVQL_XemThongTin_NV";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }
    }
}

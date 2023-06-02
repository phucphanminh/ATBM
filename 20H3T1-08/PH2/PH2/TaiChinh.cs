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
    public partial class TaiChinh : Form
    {
        public TaiChinh()
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
        }

        private void Load_ComboBox(string query_str, ComboBox NameComboBox, String col_name)
        {
            NameComboBox.Items.Clear();
            OracleConnection con = MyConnect.GetConn();
            OracleCommand cmd = new OracleCommand(query_str, con);
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string MANV = dr[col_name].ToString();
                NameComboBox.Items.Add(MANV);
            }
            con.Close();
        }

        private void bntXemTTCaNhan_Click(object sender, EventArgs e)
        {
            InitThongTinCaNhan();

        }

        private void bntXemPC_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Phân Công";
            string query_sentence_1 = "select * from GROUP08.QLNV_PHANCONG";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void bntXemPB_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Phòng Ban";
            string query_sentence_1 = "select * from GROUP08.QLNV_PHONGBAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void bntXemDA_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Đề Án";
            string query_sentence_1 = "select * from GROUP08.QLNV_DEAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void bntXemNhanVien_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Nhân Viên";
            string query_sentence_1 = "select * from GROUP08.QLNV_NHANVIEN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;

            groupBox_CNLuong.Visible = true;
            string query_string = "select MANV from GROUP08.QLNV_NHANVIEN";
            Load_ComboBox(query_string, comboBox_NhanVien_CN_Luong, "MANV");
        }

        private void bnt_CNLuong_Click(object sender, EventArgs e)
        {
            if(comboBox_NhanVien_CN_Luong.Text == "" || (txtLuong_Moi.Text == "" && txt_PhuCapMoi.Text == ""))
            {
                MessageBox.Show("Vui lòng Nhập Đủ Thông Tin!");
            }
            else
            {
                string query_string = "update GROUP08.QLNV_NHANVIEN set ";
                if (txtLuong_Moi.Text != "")
                {
                    query_string += " luong = '" + txtLuong_Moi.Text + "',";
                }
                if (txt_PhuCapMoi.Text != "")
                {
                    query_string += " phucap = '" + txt_PhuCapMoi.Text + "',";
                }
                if (query_string.Last() == ',')
                {
                    query_string = query_string.Remove(query_string.Length - 1, 1);
                }
                query_string += " where manv = '" + comboBox_NhanVien_CN_Luong.Text + "'";
                Console.WriteLine(query_string);
                OracleConnection con = MyConnect.GetConn();
                con.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand(query_string, con);
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Lỗi Cập Nhật" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Cập Nhật Thành Công", "success");
            }
        }
    }
}

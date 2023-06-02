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
    public partial class NhanSu : Form
    {
        public NhanSu()
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
            groupBox_CN_PB.Visible = false;
            InitThongTinCaNhan();
        }

        private void bntXemPC_Click(object sender, EventArgs e)
        {
            groupBox_CN_PB.Visible = false;
            labelTable.Text = "Thông Tin Phân Công";
            string query_sentence_1 = "select * from GROUP08.XemThongTinPhanCong";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void bntXemPB_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Phòng Ban";
            string query_sentence_1 = "select * from GROUP08.QLNV_PHONGBAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;

            groupBox_CN_PB.Visible = true;
            string query_string_1 = "select MAPB from GROUP08.QLNV_PHONGBAN";
            Load_ComboBox(query_string_1, comboBox_MAPB_Sua, "MAPB");
            string query_string_2 = "select MANV from GROUP08.NS_XemThongTin_NV";
            Load_ComboBox(query_string_2, comboBox_TRUONGPHONG_Moi, "MANV");

            groupBox_ThemPB.Visible = true;
            Load_ComboBox(query_string_2, comboBox_TP_Moi, "MANV");
        }

        private void bntXemDA_Click(object sender, EventArgs e)
        {
            groupBox_CN_PB.Visible = false;
            labelTable.Text = "Thông Tin Đề Án";
            string query_sentence_1 = "select * from GROUP08.QLNV_DEAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void bntCapNhat_Click(object sender, EventArgs e)
        {
            if(comboBox_TRUONGPHONG_Moi.Text == "" || (txt_TENPHONG_Moi.Text == "" && comboBox_TRUONGPHONG_Moi.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
            else
            {
                string query_string_1 = "update GROUP08.QLNV_PHONGBAN set ";
                if (txt_TENPHONG_Moi.Text != "")
                {
                    query_string_1 += " TENPB = '" + txt_TENPHONG_Moi.Text + "',";
                }
                if (comboBox_TRUONGPHONG_Moi.Text != "")
                {
                    query_string_1 += " TRPHG = '" + comboBox_TRUONGPHONG_Moi.Text + "',";
                }
                if (query_string_1.Last() == ',')
                {
                    query_string_1 = query_string_1.Remove(query_string_1.Length - 1, 1);
                }
                query_string_1 += " where MAPB = '" + comboBox_MAPB_Sua.Text + "'";
                OracleConnection con = MyConnect.GetConn();
                con.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand(query_string_1, con);
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Lỗi Cập Nhật" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Cập Nhật Thành Công", "success");
                Console.WriteLine(query_string_1);
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_MAPB_Moi.Text == "" ||txt_TP_Moi.Text == "" || comboBox_TP_Moi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
            }
            else
            {
                string queryString_1 = string.Format("insert into GROUP08.QLNV_PHONGBAN values('{0}','{1}','{2}')",txt_MAPB_Moi.Text,txt_TP_Moi.Text,comboBox_TP_Moi.Text);
                OracleConnection con = MyConnect.GetConn();
                con.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand(queryString_1, con);
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Lỗi Thêm Mới " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Thêm Mới Thành Công", "success");
                Console.WriteLine(queryString_1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox_CN_PB.Visible = false;
            bntCapNhatNV.Visible = true;
            bntThemNV.Visible = true;
            labelTable.Text = "Thông Tin Nhân Viên";
            string query_sentence_1 = "select * from GROUP08.NS_XemThongTin_NV";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void bntThemNV_Click(object sender, EventArgs e)
        {
            NhanSu_Them_NhanVien newM = new NhanSu_Them_NhanVien();
            newM.Show();
        }

        private void bntCapNhatNV_Click(object sender, EventArgs e)
        {
            NhanSu_CapNhat_NhanVien newN = new NhanSu_CapNhat_NhanVien();
            newN.Show();
        }
    }
}

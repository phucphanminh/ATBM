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
    public partial class TruongDeAn : Form
    {
        public TruongDeAn()
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

        private void bntXemTTCaNhan_Click(object sender, EventArgs e)
        {
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

        private void bntXemPC_Click(object sender, EventArgs e)
        {
            labelTable.Text = "Thông Tin Phân Công";
            string query_sentence_1 = "select * from GROUP08.XemThongTinPhanCong";
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

            groupBox1.Visible = true;
            groupBox2.Visible = true;
            string query_string = "select MADA from GROUP08.QLNV_DEAN";
            Load_ComboBox(query_string, comboBox_MADA, "MADA");
            string query_string_1 = "select MAPB from GROUP08.QLNV_PHONGBAN";
            Load_ComboBox(query_string_1, ComboBox_Phong_1, "MAPB");
            Load_ComboBox(query_string_1, ComboBox_Phong, "MAPB");
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "update GROUP08.QLNV_DEAN set ";
            if (comboBox_MADA.Text == "" || (textBox1.Text == "" && textBox2.Text == "" && ComboBox_Phong_1.Text == ""))
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
            }
            else
            {
                if (textBox1.Text != "")
                {
                    query_sentence_1 += " TENDA = '" + textBox1.Text + "',";
                }
                if (textBox2.Text != "")
                {
                    query_sentence_1 += " NGAYBD = to_date('" + textBox2.Text + "','mm/dd/yyyy'),";
                }
                if (ComboBox_Phong_1.Text != "")
                {
                    query_sentence_1 += " PHONG = '" + ComboBox_Phong_1.Text + "'";
                }
            }
            if (query_sentence_1.Last() == ',')
            {
                query_sentence_1 = query_sentence_1.Remove(query_sentence_1.Length - 1, 1);
            }
            query_sentence_1 += " where MADA = '" + comboBox_MADA.Text + "'";
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox_MADA.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
            }
            else
            {
                string query_string = "delete GROUP08.QLNV_DEAN where MADA = '" + comboBox_MADA.Text + "'";
                OracleConnection con = MyConnect.GetConn();
                con.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand(query_string, con);
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Lỗi Xoá " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Xoá Thành Công", "success");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length * textBox4.Text.Length * textBox3.Text.Length * ComboBox_Phong.Text.Length == 0)
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
            }
            else
            {
                string query_string = string.Format("insert into GROUP08.QLNV_DEAN values ('{0}','{1}', to_date('{2}','mm/dd/yyyy'), '{3}')", textBox5.Text, textBox4.Text, textBox3.Text, ComboBox_Phong.Text);
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
                    MessageBox.Show("Lỗi Thêm Mới " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Thêm Mới Thành Công", "success");
            }
        }
    }
}

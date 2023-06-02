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
    public partial class TruongPhong : Form
    {
        public TruongPhong()
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
                return;
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
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            InitThongTinCaNhan();
        }

        private void bntXemPB_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            labelTable.Text = "Thông Tin Phòng Ban";
            string query_sentence_1 = "select * from GROUP08.QLNV_PHONGBAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void btnXemDSDeAn_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            labelTable.Text = "Thông Tin Đề Án";
            string query_sentence_1 = "select * from GROUP08.QLNV_DEAN";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void bntXemPC_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            labelTable.Text = "Thông Tin Phân Công";
            string query_sentence_1 = "select * from GROUP08.XemThongTinPhanCong";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;

            labelTable.Text = "DS Phân Công Của Nhân Viên";
            string query_sentence_1 = "select * from GROUP08.TP_XemPC_NV";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;


            groupBox1.Visible = true;
            groupBox2.Visible = true;
            string query_sentence_listMANV = "select MANV from GROUP08.TP_XemPC_NV";
            string query_sentence_listMADA = "select MADA from GROUP08.QLNV_DEAN";

            comboBoxNhanVien_Sua.Text = null;
            comboBoxNhanVien_Sua.Items.Clear();
            comboBox_CN_DAMoi.Items.Clear ();
            Load_ComboBox(query_sentence_listMANV, comboBoxNhanVien_Sua, "MANV");
            Load_ComboBox(query_sentence_listMADA, comboBox_CN_DAMoi, "MADA");
        }

        private void bntXemDSNVTrongPhong_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            
            labelTable.Text = "DS Nhân Viên Trong Phòng";
            string query_sentence_1 = "select * from GROUP08.TP_XemThongTin_NV";
            OracleDataAdapter tables_Adp = new OracleDataAdapter(query_sentence_1, MyConnect.GetConn());
            DataTable Table = new DataTable();
            tables_Adp.Fill(Table);
            dataGridTable.DataSource = Table;

            string query_sentence_2 = "select MANV from GROUP08.TP_XemThongTin_NV";
            string query_sentence_3 = "select MADA from GROUP08.QLNV_DEAN";
            Load_ComboBox(query_sentence_2, comboBox_MANV_Moi, "MANV");
            Load_ComboBox(query_sentence_3, comboBox_MADA_Moi, "MADA");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox_MANV_Moi.Text == "" || comboBox_MADA_Moi.Text =="" || txt_THOIGIAN_Moi.Text == "")
            {
                MessageBox.Show("Vui Lòng Chọn Đủ Thông Tin Cần Thiết Để Thêm Mới!");
            }
            else
            {
                string query_string = string.Format("insert into GROUP08.TP_XemPC_NV values('{0}','{1}',to_date('{2}','mm/dd/yyyy'))", comboBox_MANV_Moi.Text, comboBox_MADA_Moi.Text, txt_THOIGIAN_Moi.Text);
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
                    MessageBox.Show("Lỗi Thêm Đề Án " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Thêm Thành Công", "success");
            }    
            
        }

        private void dataGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if (dataGridTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridTable.CurrentRow.Selected = true;
                textBox1.Text = dataGridTable.Rows[e.RowIndex].Cells["MANV"].FormattedValue.ToString();
            }*/
        }

        private void comboBoxNhanVien_Sua_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query_string = "select MADA from GROUP08.TP_XemPC_NV where MANV = '" + comboBoxNhanVien_Sua.Text.Trim() + "'";
            comboBox_DeAnCuaNV.Items.Clear();
            comboBox_DeAnCuaNV.Text = null;
            Load_ComboBox(query_string, comboBox_DeAnCuaNV, "MADA");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBoxNhanVien_Sua.Text == "" || comboBox_DeAnCuaNV.Text == "")
            {
                MessageBox.Show("Vui Lòng Chọn Thông Tin Muốn Chỉnh Sửa");
                return;
            }
            else
            {
                string query_sentence_1 = "update GROUP08.TP_XemPC_NV set ";
                if (comboBox_CN_DAMoi.Text == "" && txt_CN_TGMoi.Text == "")
                {
                    MessageBox.Show("Vui Lòng Chọn Thông Tin Mới");
                    return;
                }
                else
                {
                    if (txt_CN_TGMoi.Text != "")
                    {
                        query_sentence_1 += " thoigian = to_date('" + txt_CN_TGMoi.Text + "','mm/dd/yyyy'),";
                    }
                    if (comboBox_CN_DAMoi.Text != "")
                    {
                        query_sentence_1 += " mada = '" + comboBox_CN_DAMoi.Text + "'";
                    }
                }
                if (query_sentence_1.Last() == ',')
                {
                    query_sentence_1 = query_sentence_1.Remove(query_sentence_1.Length - 1, 1);
                }
                query_sentence_1 += " where manv = '" + comboBoxNhanVien_Sua.Text + "' and mada = '" + comboBox_DeAnCuaNV.Text + "'";
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
        }

        private void comboBox_DeAnCuaNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBoxNhanVien_Sua.Text == "" || comboBox_DeAnCuaNV.Text == "")
            {
                MessageBox.Show("Vui Lòng Chọn Đủ Thông Tin Cần Xoá!");
            }
            else
            {
                string query_sentence_1 = "delete GROUP08.TP_XemPC_NV where manv = '" + comboBoxNhanVien_Sua.Text + "' and mada = '" + comboBox_DeAnCuaNV.Text + "'";
                Console.WriteLine(query_sentence_1);
                OracleConnection con = MyConnect.GetConn();
                con.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand(query_sentence_1, con);
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Lỗi Xoá Phân Công " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                MessageBox.Show("Xoá Thành Công", "success");
            }
        }
    }
}

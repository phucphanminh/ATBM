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
    public partial class NhanSu_CapNhat_NhanVien : Form
    {
        public NhanSu_CapNhat_NhanVien()
        {
            InitializeComponent();
            string query_string = "select MANV from GROUP08.NS_XemThongTin_NV";
            Load_ComboBox(query_string, comboBox_MANV_Sua, "MANV");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string query_sentence_1 = "update GROUP08.NS_XemThongTin_NV set ";
            if (comboBox_MANV_Sua.Text == "" || txtGT.Text == "" && txtHoTen.Text == "" && txtNS.Text == "" && comboBox_PhongBan.Text == "" && txtSDT.Text == "" && comboBox_NVQL.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để cập nhật!");
            }
            else
            {
                if (txtGT.Text != "")
                {
                    query_sentence_1 += " phai = '" + txtGT.Text + "',";
                }
                if (txtHoTen.Text != "")
                {
                    query_sentence_1 += " TENNV = '" + txtHoTen.Text + "',";
                }
                if (txtNS.Text != "")
                {
                    query_sentence_1 += " NGAYSINH = to_date('" + txtNS.Text + "','mm/dd/yyyy'),";
                }
                if (comboBox_PhongBan.Text != "")
                {
                    query_sentence_1 += " PHG = '" + comboBox_PhongBan.Text + "',";
                }
                if (txtSDT.Text != "")
                {
                    query_sentence_1 += " SODT = '" + txtSDT.Text + "',";
                }
                if (comboBox_NVQL.Text != "")
                {
                    query_sentence_1 += " MANQL = '" + comboBox_NVQL.Text + "',";
                }
                if (query_sentence_1.Last() == ',')
                {
                    query_sentence_1 = query_sentence_1.Remove(query_sentence_1.Length - 1, 1);
                }
                query_sentence_1 += " where MANV = '" + comboBox_MANV_Sua.Text + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

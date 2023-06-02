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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Oracle.ManagedDataAccess.Client; // Oracle Client Library
using System.Configuration;// To Access App Config Attributes

namespace PH2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bntLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                MessageBox.Show("Nhập Username");
            }
            else if( txtPassword.Text == "")
            {
                MessageBox.Show("Nhập Password");
            }
            else
            {
                /*OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));  User Id=GROUP08;Password=;");*/
                String connStr = string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe))); User Id={0};Password={1};",txtUsername.Text.Trim(), txtPassword.Text.Trim());
                Console.WriteLine(connStr);
                using (OracleConnection conn = new OracleConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        DataSet dsetas1 = new DataSet();
                        string query_sentence_1 = "select VAITRO from GROUP08.xemthongtincanhan where MANV = SYS_CONTEXT ('USERENV', 'SESSION_USER')";
                        OracleDataAdapter data1 = new OracleDataAdapter(query_sentence_1, conn);
                        data1.SelectCommand.CommandType = CommandType.Text;
                        data1.Fill(dsetas1);
                        MyConnect.ConnString = connStr;
                        if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "GD")
                        {
                            
                            GiamDoc GD = new GiamDoc();
                            GD.Show();
                        }
                        else if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "NV")
                        {
                            
                            NhanVien NV = new NhanVien();
                            NV.Show();
                        }
                        else if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "NVQL")
                        {
                           
                            QLTrucTiep NVQL = new QLTrucTiep();
                            NVQL.Show();
                        }
                        else if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "TP")
                        {
                           
                            TruongPhong TP = new TruongPhong();
                            TP.Show();
                        }
                        else if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "TC")
                        {
         
                            TaiChinh TC = new TaiChinh();
                            TC.Show();
                        }
                        else if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "NS")
                        {

                            NhanSu NS = new NhanSu();
                            NS.Show();
                        }
                        else if (dsetas1.Tables[0].Rows[0]["VAITRO"].ToString() == "TDA")
                        {

                            TruongDeAn TDA = new TruongDeAn();
                            TDA.Show();
                        }
                        else
                        {
                            MessageBox.Show("Mày là ai?");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

public static class MyConnect
{
    public static string ConnString;
    public static OracleConnection GetConn()
    {
        OracleConnection con = new OracleConnection(ConnString);
        return con;
    }
}

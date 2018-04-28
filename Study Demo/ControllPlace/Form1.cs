using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ControllPlace
{
    public partial class Form1 : Form
    {

        string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string sql = "select * from RtdbTransPlace";
        DataTable dt = new DataTable();
        SqlDataAdapter da;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = SqlData();            
        }

        private void Save_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(connstr))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);


                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                try
                {
                    da.Update(dt);
                    MessageBox.Show("保存成功");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        //显示datagridview
        public void S()
        {
         

        }


        //连接数据库,读取数据
        private DataTable SqlData()
        {
           
            using (SqlConnection con=new SqlConnection(connstr))
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(sql,con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

 

    }
}

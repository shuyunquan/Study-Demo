using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlHelper
    {
        string connstr = ConfigurationManager.ConnectionStrings["CONNECTIONS"].ConnectionString;

        //返回Table
        public DataTable SqlConnectionInformation(string sql)
        {

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //string sql = "select * from table";
                SqlCommand com = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(dt);
            }

            return dt;

        }

        //判断登录信息的
        public string SqlQuery(string id, string pword)
        {
            string sql = "select* from sysUser where AccountNumber =@id  and Password = @pword";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand com = new SqlCommand(sql, conn);
                SqlParameter[] parameters = {
                new SqlParameter("@id",SqlDbType.VarChar,12),
                new SqlParameter("@pword",SqlDbType.VarChar,12)
                };
                parameters[0].Value = id;
                parameters[1].Value = pword;
                com.Parameters.AddRange(parameters);

                if (com.ExecuteScalar() != null)
                {
                    string user_Name = com.ExecuteScalar().ToString();

                    if (user_Name == id)
                    {

                        return "yes";
                    }
                    else
                    {

                        return "no";
                    }
                }
                else
                {
                    return "no";
                }



            }

        }

        //增删改
        public int Excute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //string sql = "select * from table";
                SqlCommand com = new SqlCommand(sql, conn);
                int result = com.ExecuteNonQuery();
                return result;

            }

        }

    }
}

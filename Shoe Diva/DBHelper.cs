using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoe_Diva
{
    internal class DBHelper
    {
        //连接数据库
        private static string connString = "Data Source=(localdb)\\MSSQLLocalDB;Trusted_Connection = SSPI;Initial Catalog=C:\\USERS\\JAN29TH\\SOURCE\\REPOS\\SHOE DIVA\\SHOE DIVA\\DATABASE.MDF;Integrated Security=True";
        private static SqlConnection conn = new SqlConnection(connString);
        public static void execute(String sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public static DataSet GetDataSet(string sql)
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}

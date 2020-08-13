using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KMDIWinDoorsCS
{
    class csQueries
    {
        Class.csFunctions csfunc = new Class.csFunctions();

        string sqlConStr = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='KMDIDATA';User ID='kmdiadmin';Password='kmdiadmin';";

        SqlCommand sqlcmd;
        SqlDataReader sqlread;
        SqlConnection sqlcon;
        SqlTransaction sqltrans;

        public List<object> Login(string username, string password)
        {
            List<object> info = new List<object>();
            using (sqlcon = new SqlConnection(sqlConStr))
            {
                sqlcon.Open();
                using (sqlcmd = sqlcon.CreateCommand())
                {
                    sqltrans = sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "stp_Login");
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.Transaction = sqltrans;
                    sqlcmd.CommandText = "stp_Login";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserName", username);
                    sqlcmd.Parameters.AddWithValue("@Password", csfunc.Encrypt(password));
                    sqlread = sqlcmd.ExecuteReader();
                    sqlread.Read();
                    foreach (var item in sqlread)
                    {
                        info.Add(item);
                    }
                }
            }
            return info;
        }
    }
}

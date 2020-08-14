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

        public List<object> Login(string username, string password)
        {
            List<object> info = new List<object>();
            using (SqlConnection sqlcon = new SqlConnection(sqlConStr))
            {
                sqlcon.Open();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "stp_Login"))
                    {
                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "stp_Login";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@UserName", username);
                        sqlcmd.Parameters.AddWithValue("@Password", csfunc.Encrypt(password));
                        using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                info.Add(rdr.GetInt32(0));  //[AUTONUM]
                                info.Add(rdr.GetString(1)); //[FULLNAME]
                                info.Add(rdr.GetString(2)); //[NICKNAME]
                                info.Add(rdr.GetString(3)); //[ACCTTYPE]
                                info.Add(rdr.GetString(4)); //[USERNAME]
                                info.Add(rdr.GetString(5)); //[PASSWORD]
                                info.Add(rdr.GetString(6)); //[PROFILEPATH]
                            }
                        }
                    }
                }
            }
            return info;
        }
    }
}

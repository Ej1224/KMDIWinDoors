using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace KMDIWinDoorsCS
{
    class csQueries
    {
        Class.csFunctions csfunc = new Class.csFunctions();

        string sqlConStr = Properties.Settings.Default.dbCon;

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
        
        public Tuple<string, DataSet> CostingQuery_ReturnDS(string todo,
                                                            string searchstr,
                                                            int acctno) // function for Select STATEMENTS
        {
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataSet sqlds = new DataSet();
            string sql_Transaction_result = "";

            using (SqlConnection sqlcon = new SqlConnection(sqlConStr))
            {
                sqlcon.Open();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    SqlTransaction sqltrans = sqlcon.BeginTransaction("Costing_STP");
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.Transaction = sqltrans;
                    sqlcmd.CommandText = "Costing_STP";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add("@todo",SqlDbType.VarChar).Value = todo;
                    sqlcmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = "%" + searchstr + "%";
                    sqlcmd.Parameters.Add("@intVar", SqlDbType.Int).Value = acctno;
                    sqlcmd.Parameters.Add("@C_File_addr", SqlDbType.VarChar).Value = "";
                    sqltrans.Commit();
                    sql_Transaction_result = "Committed";

                    sqlda.SelectCommand = sqlcmd;
                    sqlda.Fill(sqlds, todo);
                }
            }
            return Tuple.Create(sql_Transaction_result, sqlds);
        }

        public bool CostingQuery_ReturnBool(string todo,
                                            string C_File_addr,
                                            int acctno) //function for Insert, Update and Delete STATEMENTS
        {
            int count = 0;
            using (SqlConnection sqlcon = new SqlConnection(sqlConStr))
            {
                sqlcon.Open();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    SqlTransaction sqltrans = sqlcon.BeginTransaction("Costing_STP");
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.Transaction = sqltrans;
                    sqlcmd.CommandText = "Costing_STP";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add("@SearchString", SqlDbType.VarChar).Value = "";
                    sqlcmd.Parameters.Add("@todo", SqlDbType.VarChar).Value = todo;
                    sqlcmd.Parameters.Add("@C_File_addr", SqlDbType.VarChar).Value = C_File_addr;
                    sqlcmd.Parameters.Add("@intVar", SqlDbType.Int).Value = acctno;
                    count = sqlcmd.ExecuteNonQuery();

                    sqltrans.Commit();
                }
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

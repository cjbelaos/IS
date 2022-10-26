using IS.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IS.GlobalClasses
{
    public class TransationsMaintenance
    {
        private readonly string Inventory;

        public TransationsMaintenance()
        {
            this.Inventory = ConfigurationManager.ConnectionStrings["Inventory"].ConnectionString;
        }

        public DataTable GetTransactions()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    using (var cmd = new SqlCommand("sp_get_transactions", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string AddTransaction(ClassTransaction transaction)
        {
            string Message = "";
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_add_transaction", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("@transactiontype", transaction.transactiontype);
                        cmd.Parameters.AddWithValue("@quantity", transaction.quantity);
                        cmd.Parameters.AddWithValue("@itemid", transaction.itemid);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.Message.ToString();
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
            }
            return Message;
        }

        public string UpdateItem(ClassTransaction transaction)
        {
            string Message = "";
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_update_transaction", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("@id", transaction.id);
                        cmd.Parameters.AddWithValue("@transactiontype", transaction.transactiontype);
                        cmd.Parameters.AddWithValue("@quantity", transaction.quantity);
                        cmd.Parameters.AddWithValue("@itemid", transaction.itemid);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.Message.ToString();
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
            }
            return Message;
        }

        public string DeleteItem(ClassTransaction transaction)
        {
            string Message = "";
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_delete_transaction", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("@id", transaction.id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Message = sqlex.Message.ToString();
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
            }
            return Message;
        }
    }
}

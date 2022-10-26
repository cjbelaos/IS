using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IS.Classes
{
    public class ItemsMaintenance
    {
        private readonly string Inventory;

        public ItemsMaintenance()
        {
            this.Inventory = ConfigurationManager.ConnectionStrings["Inventory"].ConnectionString; 
        }

        public DataTable GetItems()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    using (var cmd = new SqlCommand("sp_get_items", conn) { CommandType = CommandType.StoredProcedure })
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

        public string AddItem(ClassItem item)
        {
            string Message = "";
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_add_item", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("@itemcode", item.itemcode);
                        cmd.Parameters.AddWithValue("@itemdescription", item.itemdescription);
                        cmd.Parameters.AddWithValue("@unitprice", item.unitprice);
                        cmd.Parameters.AddWithValue("@srp", item.srp);
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

        public string UpdateItem(ClassItem item)
        {
            string Message = "";
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_update_item", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("@id", item.id);
                        cmd.Parameters.AddWithValue("@itemcode", item.itemcode);
                        cmd.Parameters.AddWithValue("@itemdescription", item.itemdescription);
                        cmd.Parameters.AddWithValue("@unitprice", item.unitprice);
                        cmd.Parameters.AddWithValue("@srp", item.srp);
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

        public string DeleteItem(ClassItem item)
        {
            string Message = "";
            try
            {
                using (var conn = new SqlConnection(Inventory))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("sp_delete_item", conn) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("@id", item.id);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IS.GlobalClasses
{
    public class TransactionTypeMaintenance
    {
        public DataTable GetTransactionTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("TransactionType");
            dt.Rows.Add("1","Incoming");
            dt.Rows.Add("2","Outgoing");
            return dt;
        }
    }
}

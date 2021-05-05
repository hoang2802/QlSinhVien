using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace QlSinhVien
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source = LAPTOP-U4746TND\\SQLEXPRESS; Initial Catalog=QLSinhVien; Integrated Security=true";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}

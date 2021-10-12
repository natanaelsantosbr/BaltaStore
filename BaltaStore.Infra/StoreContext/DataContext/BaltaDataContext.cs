using BaltaStore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Infra.StoreContext.DataContext
{
    public class BaltaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaltaDataContext()
        {
            this.Connection = new SqlConnection(Settings.ConnectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            if (this.Connection.State != ConnectionState.Closed)
                this.Connection.Close();
        }
    }
}

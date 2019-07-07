using VIN.Infra.Data.Context.Enums;
using VIN.Infra.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Infra.Data.Context.Db
{
    /// <summary>
    /// Contexto para conectar com SQL Server
    /// </summary>
    public sealed class SqlServerContext : DbContext
    {
        public SqlServerContext() : base()
        {
            this.Provider = DatabaseProviders.SQL_SERVER;
            this.ConnectionStringName = "DefaultConnection";
        }
    }
}

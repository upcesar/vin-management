using Microsoft.Extensions.Configuration;
using VIN.Infra.Data.Context.Enums;

namespace VIN.Infra.Data.Context.Db
{
    /// <summary>
    /// Contexto para conectar com SQL Server
    /// </summary>
    public sealed class SqlServerContext : DbContext
    {
        public SqlServerContext(IConfiguration configuration) : base(configuration)
        {
            this.Provider = DatabaseProviders.SQL_SERVER;
            this.ConnectionStringName = "DefaultConnection";
        }
    }
}

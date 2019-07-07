using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using VIN.Infra.Data.Context.Enums;
using VIN.Infra.Data.Context.Interfaces;

namespace VIN.Infra.Data.Context.Db
{
    /// <summary>
    /// Factory para criar conexões a partir do Provider Selecionado.
    /// </summary>
    public static class DbConnectionFactory
    {
        /// <summary>
        /// Criar uma nova conexão de banco de dados com o provider selecionado.
        /// Gera Exception, caso não for definido dentro da lista
        /// </summary>
        /// <param name="provider">Lista de Provider / Drivers disponíveis</param>
        /// <param name="connectionString">String de conexão com a base de dados</param>
        /// <returns>Uma conexão pronta para abrir</returns>
        public static IDbConnection Create<T>(T dbContext) where T : IDbContext
        {
            if (string.IsNullOrEmpty(dbContext.ConnectionString))
            {
                throw new ArgumentException("O valor não deve estar vazio", nameof(dbContext.ConnectionString));
            }

            switch (dbContext.Provider)
            {
                case DatabaseProviders.SQL_SERVER:
                    return new SqlConnection(dbContext.ConnectionString);
                case DatabaseProviders.ORACLE:
                    return new OracleConnection(dbContext.ConnectionString);
                case DatabaseProviders.POSGRE:
                    return new NpgsqlConnection(dbContext.ConnectionString);
            }

            throw new ArgumentException("Driver de banco de dados inválido");
        }
    }
}

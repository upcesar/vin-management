using VIN.Infra.Data.Context.Enums;
using VIN.Infra.Data.Context.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace VIN.Infra.Data.Context.Db
{
    /// <summary>
    /// Clase base para criar contextos. Não pode ser instanciada diretamente
    /// </summary>
    public abstract class DbContext : IDbContext
    {
        #region Atributes

        /// <summary>
        /// Conexão associada ao Contexto. Atributo de só leitura (ReadOnly)
        /// </summary>
        public IDbConnection Connection { get; protected set; }

        /// <summary>
        /// Lista de enumerados do Provider a escolher para a conexão.
        /// Atributo só leitura que permite  a alteração dentro la classe derivada.
        /// Para alterar fora da classe, usar o método SetProvider()
        /// </summary>
        public DatabaseProviders Provider { get; protected set; }

        /// <summary>
        /// Nome da String de Conexão configurada no arquivo "connections_string.json". 
        /// Atributo editável de só leitura (ReadOnly) para as classes 
        /// </summary>
        public string ConnectionStringName { get; protected set; }

        /// <summary>
        /// Nome da String de Conexão configurada no arquivo "appsetting.json". 
        /// Atributo editável de só leitura (ReadOnly) para as classes 
        /// </summary>
        public string ConnectionString { get; private set; }

        #endregion

        #region Constructor

        public DbContext()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Seleciona o contexto a partir do Provider / Driver de banco selecionado
        /// </summary>
        /// <returns>Objecto que implementa a interface IbContext</returns>
        public IDbContext SelectContext()
        {
            ConnectDatabase();

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            return this;
        }


        /// <summary>
        /// Fecha e libera a conexão com o banco de dados.
        /// </summary>
        public void Dispose()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }

            Connection?.Dispose();
        }

        #endregion

        #region Private Methods

        private void ConnectDatabase()
        {
            ConnectionString = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build()
                                    .GetSection($"ConnectionStrings:{ConnectionStringName}")
                                    .Value ?? string.Empty;

            this.Connection = this.Connection ?? DbConnectionFactory.Create(this);
        }
        
        #endregion

    }
}

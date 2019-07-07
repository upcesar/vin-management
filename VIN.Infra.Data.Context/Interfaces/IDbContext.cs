using VIN.Infra.Data.Context.Enums;
using System;
using System.Data;

namespace VIN.Infra.Data.Context.Interfaces
{
    /// <summary>
    /// Interface para definir o contexto de uma conexão de base de dados a partir de um Provider / Driver.
    /// Drivers disponíveis: SQL Server, Oracle e Posgre.
    /// </summary>
    public interface IDbContext : IDisposable        
    {
        /// <summary>
        /// Lista de enumerados do Provider a escolher para a conexão.
        /// Atributo só leitura que permite  a alteração dentro la classe derivada.
        /// Para alterar fora da classe, usar o método SetProvider()
        /// </summary>
        DatabaseProviders Provider { get; }

        /// <summary>
        /// Conexão associada ao Contexto. Atributo de só leitura (ReadOnly)
        /// </summary>
        IDbConnection Connection { get; }

        /// <summary>
        /// Nome da String de Conexão configurada no arquivo "connections_string.json". 
        /// Atributo editável de só leitura (ReadOnly) para as classes 
        /// </summary>
        string ConnectionStringName { get; }
        
        /// <summary>
        /// String de Conexão com o banco de dados. Atributo de só leitura (ReadOnly)
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Efetua a conexão com a base de dados a partir do Provider / Driver selecionado
        /// </summary>
        /// <returns>Objecto que implementa a interface IbContext</returns>
        IDbContext SelectContext();
    }
}

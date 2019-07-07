using VIN.Infra.Data.Context.Interfaces;
using System;

using VIN.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using DapperExtensions;

namespace VIN.Infra.Data
{
    /// <summary>
    /// Classe base abstrata para operações CRUD dentro do repositório
    /// </summary>
    /// <typeparam name="TEntity">Tipo de Entidade que efetuará as operações dentro do repositório</typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region Atributes       

        /// <summary>
        /// Conexão associada ao repositório
        /// </summary>
        protected IDbConnection Connection { get; set; }

        protected IDbTransaction Transaction { get; set; }

        #endregion

        #region Constructors

        public BaseRepository(IUnitOfWork uow)
        {
            var context = uow.Context.SelectContext();

            Transaction = uow.Transaction;
            Connection = context.Connection;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Inserir uma entidade no repositório
        /// </summary>
        /// <param name="entity">Entidade a inserir</param>
        /// <returns>Boolean para informar se a entidade foi inserida ou não</returns>
        public bool Insert(TEntity entity)
        {
            var inserted = entity == null ? null : Connection.Insert(entity, Transaction);

            return (inserted != null);
        }

        /// <summary>
        /// Efetua uma inserção de várias entidades numa única execução. Util na hora de efetuar importação de distintas fontes de dados.
        /// </summary>
        /// <param name="entities">Lista de entidades a inserir no repositório</param>
        /// <returns>Boolean para informar se a lista de entidades foi inserida ou não</returns>
        public void Insert(IEnumerable<TEntity> entities)
        {
            Connection.Insert(entities, Transaction);
        }

        /// <summary>
        /// Obter uma lista de entidade sem filtro
        /// </summary>
        /// <returns>Lista de entiades</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Connection.GetList<TEntity>(null, null, Transaction);
        }

        /// <summary>
        /// Obter uma entidade a partir do Id
        /// </summary>
        /// <param name="id">ID da entidade</param>
        /// <returns>Entidade carregada com os dados</returns>
        public TEntity GetById(string id)
        {
            return Connection.Get<TEntity>(id, Transaction);
        }

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity">Entidade a atualizar</param>
        /// <returns>Boolean para informar se a entidade foi atualizada ou não</returns>
        public bool Update(TEntity entity)
        {
            return entity != null && Connection.Update(entity, Transaction);
        }

        /// <summary>
        /// Exclui uma entidade
        /// </summary>
        /// <param name="entity">Entidade a excluir</param>
        /// <returns>Boolean para informar se a entidade foi excluída ou não</returns>
        public bool Delete(TEntity entity)
        {
            return entity != null && Connection.Delete(entity, Transaction);
        }

        /// <summary>
        /// Fecha e libera a conexão atual e cancela a transação, caso tiver transação aberta.
        /// </summary>
        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
            }

            Connection?.Dispose();
        }
        
        #endregion

    }
}

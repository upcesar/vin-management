using VIN.Infra.Data.Context.Interfaces;
using System;
using System.Data;

namespace VIN.Infra.Context
{
    /// <summary>
    /// Clase Unit Of Work, cuja finalidade é manter uma lista de objetos afetados por uma transação, coordenar a escrita de mudanças e tratar possíveis problemas de concorrência.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Atributes

        /// <summary>
        /// Contexto utilizado no Unit Of Work, injetado via construtor
        /// </summary>
        public IDbContext Context { get; private set; }

        /// <summary>
        /// Transação da base de dados.
        /// </summary>
        public IDbTransaction Transaction { get; private set; }

        #endregion

        #region Constructors
        public UnitOfWork(IDbContext context)
        {
            Context = context;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Começar uma transação usando o nível de isolamento
        /// </summary>
        /// <param name="isolationLevel">Nívle de isolamento da transação</param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            if (Transaction == null)
            {
                Transaction = Context.Connection.BeginTransaction(isolationLevel);
            }

            return Transaction;
        }

        /// <summary>
        /// Confimar uma transação
        /// </summary>
        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                DisposeTransaction();
            }

        }

        /// <summary>
        /// Desfazer uma tarnsação
        /// </summary>
        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                DisposeTransaction();
            }
        }

        /// <summary>
        /// Descarta o objeto, fazendo as seguintes operações: 
        /// * Fazer Rollback da transação atual, se tiver.
        /// * Destroi o contexto associado.
        /// </summary>
        public void Dispose()
        {
            Rollback();

            DisposeContext();
        }

        #endregion

        #region Private Methods

        private void DisposeContext()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        private void DisposeTransaction()
        {
            Transaction.Dispose();
            Transaction = null;
        }

        #endregion
    }
}

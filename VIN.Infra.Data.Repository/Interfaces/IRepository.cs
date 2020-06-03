using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VIN.Infra.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface para operações CRUD dentro do repositório
    /// </summary>
    /// <typeparam name="TEntity">Tipo de Entidade que efetuará as operações dentro do repositório</typeparam>
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Inserir uma entidade no repositório
        /// </summary>
        /// <param name="entity">Entidade a inserir</param>
        /// <returns>Boolean para informar se a entidade foi inserida ou não</returns>
        Task<bool> Insert(TEntity entity);

        /// <summary>
        /// Efetua uma inserção de várias entidades numa única execução. Util na hora de efetuar importação de distintas fontes de dados.
        /// </summary>
        /// <param name="entities">Lista de entidades a inserir no repositório</param>
        /// <returns>Boolean para informar se a lista de entidades foi inserida ou não</returns>
        Task Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// Obter uma lista de entidade sem filtro
        /// </summary>
        /// <returns>Lista de entiades</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Obter uma entidade a partir do Id
        /// </summary>
        /// <param name="id">ID da entidade</param>
        /// <returns>Entidade carregada com os dados</returns>
        TEntity GetById(string id);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity">Entidade a atualizar</param>
        /// <returns>Boolean para informar se a entidade foi atualizada ou não</returns>
        Task<bool> Update(TEntity entity);

        /// <summary>
        /// Exclui uma entidade
        /// </summary>
        /// <param name="entity">Entidade a excluir</param>
        /// <returns>Boolean para informar se a entidade foi excluída ou não</returns>
        Task<bool> Delete(TEntity entity);
    }
}

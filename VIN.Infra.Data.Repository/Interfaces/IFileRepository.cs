using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Infra.Data.Repository.Interfaces
{
    public interface IFileRepository<TEntity> where TEntity : class
    {
        IFileRepository<TEntity> SetPath(string fullPath);
        IEnumerable<TEntity> Read();
        void Write(TEntity entity);
    }
}

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using VIN.Infra.Data.Repository.Interfaces;

namespace VIN.Infra.Data.Repository.FileSystem
{
    public class JsonRepository<TEntity> : IFileRepository<TEntity> where TEntity : class
    {
        private string _fullPath;

        public IFileRepository<TEntity> SetPath(string fullPath)
        {
            this._fullPath = fullPath;

            return this;
        }

        public IEnumerable<TEntity> Read()
        {
            var textFile = File.ReadAllText(this._fullPath);

            return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(textFile);
        }

        public void Write(TEntity entity)
        {
            var stringEntity = JsonConvert.SerializeObject(entity, Formatting.Indented);

            File.WriteAllText(this._fullPath, stringEntity);
        }
    }
}

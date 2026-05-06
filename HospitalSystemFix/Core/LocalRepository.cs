using System.Collections.Generic;

namespace HospitalSystemFix.Core
{
    public class LocalRepository<T> : IRepository<T> where T : class
    {
        private List<T> _data;

        public LocalRepository(List<T> data)
        {
            _data = data;
        }

        public IEnumerable<T> GetAll() => _data.AsReadOnly();

        public void Add(T entity) => _data.Add(entity);

        public void Remove(T entity) => _data.Remove(entity);
        
        // Helper for re-initializing after load
        internal void SetData(List<T> newData) => _data = newData;
    }
}

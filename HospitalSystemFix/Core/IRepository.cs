using System;
using System.Collections.Generic;

namespace HospitalSystemFix.Core
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
    }
}

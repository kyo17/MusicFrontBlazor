using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICRUD<T> where T : class
    {
        Task<IEnumerable<T>> getAll();
        Task<T> getById(string id);
        Task save(T entity);
        Task update(T entity);
        Task delete(string id);
    }
}

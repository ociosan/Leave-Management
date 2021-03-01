using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    /*Repository Pattern*/
    /*We pass the four classes, in this case: it's for CRUD operations*/
    public interface IRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
        Task <bool> IsExists(int id);
        Task <bool> Create(T entity);
        Task <bool> Update(T entity);
        Task <bool> Delete(T entity);
        Task <bool> Save();

    }
}

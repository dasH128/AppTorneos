using System.Collections.Generic;

namespace Parcial.Repository
{
    public interface IRepository<T>
    {
        bool  Create(T entity);
        bool  Update(T entity);

        bool  Delete(int id);


        IEnumerable<T> FindAll();

        T FindByID(int id);
    }
}
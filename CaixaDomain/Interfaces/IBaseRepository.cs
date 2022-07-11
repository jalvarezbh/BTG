using CaixaDomain.Models;
using System.Collections.Generic;

namespace CaixaDomain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Base
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        IList<TEntity> Select();

        TEntity Select(int id);
    }
}

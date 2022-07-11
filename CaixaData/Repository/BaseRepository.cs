using CaixaData.Context;
using CaixaDomain.Interfaces;
using CaixaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaData.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
    {
        protected readonly CaixaContext _caixaContext;

        public BaseRepository(CaixaContext caixaContext)
        {
            _caixaContext = caixaContext;
        }

        public void Insert(TEntity obj)
        {
            _caixaContext.Set<TEntity>().Add(obj);
            _caixaContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {           
            _caixaContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _caixaContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _caixaContext.Set<TEntity>().Remove(Select(id));
            _caixaContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _caixaContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _caixaContext.Set<TEntity>().Find(id);

    }
}

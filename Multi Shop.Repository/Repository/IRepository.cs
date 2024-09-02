using Multi_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Repository.Repository
{
    public interface IRepository<T>  where T :BaseModel
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        T GetWithInclude(Expression<Func<T, bool>> predicate, string [] includeProperties);
        IEnumerable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);

        ICollection<T> Searsh(Expression<Func<T, bool>> expression);

    }
}

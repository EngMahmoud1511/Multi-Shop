using Multi_Shop.Data.Data;
using Multi_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Repository.Repository
{
    public class Repository<T>:IRepository<T> where T :class
    {
        private ShopContext _Context;
        public Repository(ShopContext context) 
        {
            _Context = context;
        }

        public void Add(T entity)
        {
           _Context.Set<T>().Add(entity);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            
        }

        public ICollection<T> GetAll()
        {
           return  _Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _Context.Set<T>().Find(id); 
            
        }
        public ICollection<T> Searsh(Expression<Func<T, bool>> expression) 
        {
            return _Context.Set<T>().Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _Context.Set<T>().Update(entity);
            _Context.SaveChanges();
        }


        
    }
}

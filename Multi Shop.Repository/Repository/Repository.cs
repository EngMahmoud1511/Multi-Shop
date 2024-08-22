using Microsoft.EntityFrameworkCore;
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
    public class Repository<T>:IRepository<T> where T :BaseModel
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

        public void Delete(T entity)
        {
            _Context.Remove(entity);
            _Context.SaveChanges();
        }

        public ICollection<T> GetAll()
        {
           return  _Context.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            var customer= _Context.Set<T>().AsNoTracking().FirstOrDefault(x=>x.Id==id);
            _Context.Database.CloseConnection();

            return customer; 
            
        }

        public void Save()
        {
           _Context.SaveChanges();
        }

        public ICollection<T> Searsh(Expression<Func<T, bool>> expression) 
        {
            return _Context.Set<T>().Where(expression).ToList();
        }

        public void Update(T entity)
        {
           _Context.Update(entity);
           _Context.SaveChanges();

        }


        
    }
}

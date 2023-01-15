using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Projet.Models;
using System;
using System.Linq;
using System.Diagnostics;

namespace Projet.Data
{
    public interface IRepository<TEntity> where TEntity:class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate );
        
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);   
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _Context;
        public Repository(DbContext db)
        {
            this._Context = db;
        }
        public TEntity Get(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) { 
        try
            {
                return this._Context.Set<TEntity>().Where(predicate).ToList();  

            }
            
        catch (Exception ex)
         {
                Debug.WriteLine("Exception ",ex.ToString());
                throw ex;
         }
}
        public bool Add(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Add(entity);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().AddRange(entities);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Remove(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Remove(entity);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().RemoveRange(entities);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    }

using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Models;
using EP.CursoMVC.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EP.CursoMVC.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {

        protected CursoMVCContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new CursoMVCContext();
            DbSet = Db.Set<TEntity>();
        }
        public virtual TEntity Adicionar(TEntity obj)
        {
            var objRet = DbSet.Add(obj);
            SaveChanges();
            return objRet;
        }
        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;

        }
        public virtual void Remove(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
            SaveChanges();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }
        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s); // Primeiro - pegar 10 e pular 0 // Segundo - pegar 20 e pular 10 // Terceiro - pagar 30 e pular 20
        }
        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
        }

    }
}

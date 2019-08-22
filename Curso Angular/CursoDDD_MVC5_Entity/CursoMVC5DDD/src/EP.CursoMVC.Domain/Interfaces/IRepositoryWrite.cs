﻿using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();

    }
}

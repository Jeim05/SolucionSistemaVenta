using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Implementacion
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            throw new NotImplementedException();
        }


        public Task<TEntity> Crear(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> Consulta(Expression<Func<TEntity, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }
    }
}

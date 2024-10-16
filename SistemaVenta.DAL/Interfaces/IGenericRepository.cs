using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace SistemaVenta.DAL.Interfaces
{
    // decimos que ese TEntity es una clase
    public interface IGenericRepository<TEntity> where TEntity : class 
    {
        Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro);
        Task<TEntity> Crear(TEntity entidad);
        Task<bool> Editar(TEntity entidad);
        Task<bool> Eliminar(TEntity entidad);
        Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro=null);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.DAL.Implementacion
{
    // Hereda de la Clase GenericRepository y Interfaz IVenta
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        // Se implementa el contexto
        private readonly DbventaContext _dbContext;

        // Constructor
        // Se agrega base(dbContext) para especificar que se envia al GenericRepository
        public VentaRepository(DbventaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Venta> Registrar(Venta entidad)
        {
            Venta ventaGenerada = new Venta();

            // Usamos una transacción para que en caso de que ocurra un error devolver todo a como estaba al inicio
            using (var transaction = _dbContext.Database.BeginTransaction()) {
                try
                {
                    // Utilizamos foreach es cambiar el stock del producto
                    foreach(DetalleVenta dv in entidad.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p=>p.IdProducto == dv.IdProducto).First();
                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Task<List<Venta>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            throw new NotImplementedException();
        }
    }
}

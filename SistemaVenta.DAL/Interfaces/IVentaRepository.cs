using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.Entity;

namespace SistemaVenta.DAL.Interfaces
{
    // Repositorio específico para la gestión de las ventas
    // Hereda de otra interfaz, pero se especifica la Entidad estricta que se va a utilizar
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta entidad);
        Task<List<Venta>> Reporte(DateTime FechaInicio, DateTime FechaFin);
    }
}

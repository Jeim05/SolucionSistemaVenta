using SistemaVenta.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Interfaces
{
    public interface IUsuarioService
    {
        // En esta clase se incluyen todos los métodos de la clase usuario

        Task<List<Usuario>> Lista();
        Task<Usuario> Grear(Usuario entidad, Stream foto=null, string NombreFoto="", string UrlPlantilla);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        public Task<List<Usuario>> Lista()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Crear(Usuario entidad, Stream foto = null, string NombreFoto = "", string UrlPlantillaCorreo = "")
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Editar(Usuario entidad, Stream foto = null, string NombreFoto = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GuardarPerfil(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerPorCredenciales(string correo, string clave)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerPorId(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReestablecerClave(string Correo, string UrlPlantillaCorreo)
        {
            throw new NotImplementedException();
        }
    }
}

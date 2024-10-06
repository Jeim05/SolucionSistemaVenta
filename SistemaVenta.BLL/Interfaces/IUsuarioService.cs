﻿using SistemaVenta.Entity;
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
        Task<Usuario> Crear(Usuario entidad, Stream foto=null, string NombreFoto="", string UrlPlantillaCorreo="");
        Task<Usuario> Editar(Usuario entidad, Stream foto = null, string NombreFoto = "");
        Task<bool> Eliminar(int IdUsuario);
        Task<Usuario> ObtenerPorCredenciales(string correo, string clave);
        Task<Usuario> ObtenerPorId(int IdUsuario);
        Task<bool> GuardarPerfil(Usuario entidad);
        Task<bool> CambiarClave (int IdUsuario, string ClaveActual, string ClaveNueva);
        Task<bool> ReestablecerClave (string Correo, string UrlPlantillaCorreo);
    }
}

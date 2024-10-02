using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.BLL.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using SistemaVenta.Entity;
using SistemaVenta.DAL.Interfaces;

namespace SistemaVenta.BLL.Implementacion
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;

        // CONSTRUCTOR
        public FirebaseService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }


        public async Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {
            string UrlImagen = "";

            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consulta(c => c.Recurso.Equals("FireBase_Storage"));

                // Creamos un diccionario para guardar la propiedad y valor de la tabla Config
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                // Se crea la autorización
                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> SubirStorage(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo)
        {
            throw new NotImplementedException();
        }
    }
}

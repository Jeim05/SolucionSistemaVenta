using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.BLL.Interfaces;
using System.Security.Cryptography;

namespace SistemaVenta.BLL.Implementacion
{
    public class UtilidadesServices : IUtilidadesService
    {
        public string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6); //Brinda un texto aleatorio con numeros y letras entre el 0 y 6
            return clave;
        }

        public string ConvertirSha256(string texto)
        {
            
        }

        
    }
}

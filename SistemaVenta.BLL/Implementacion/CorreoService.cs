using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Implementacion
{
    public class CorreoService : ICorreoService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;
        
        //Constructor
        public CorreoService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("Servicio_Correo"));

                // Creamos un diccionario para guardar la propiedad y valor de la tabla Config
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector:c=>c.Valor);

                //Empezamos a configurar el correo
                var credencials = new NetworkCredential(Config["correo"], Config["clave"]);
                var correo = new MailMessage()
                {
                    From = new MailAddress(Config["correo"], Config["allias"]),
                    Subject = Asunto,
                    Body = Mensaje,
                    IsBodyHtml = true
                };

                correo.To.Add(new MailAddress(CorreoDestino));
                var clienteServidor = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["puerto"]),
                    Credentials =  credencials,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };

                clienteServidor.Send(correo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

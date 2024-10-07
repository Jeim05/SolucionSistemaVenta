using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.DAL.Implementacion;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.BLL.Implementacion;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration) {
            services.AddDbContext<DbventaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });


            // Transient indica que van a variar sus valores, ya que estamos trabajando con una 
            // clase generica
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // De esta manera ya estamos utilizando la inyección de depencias 
            services.AddScoped<IVentaRepository, VentaRepository>();

            // Dependencia del envio del correo
            services.AddScoped<ICorreoService, CorreoService>();

            // Dependencia de Firebase
            services.AddScoped<IFirebaseService, FirebaseService>();

            // Dependencia de las utilidades
            services.AddScoped<IUtilidadesService, UtilidadesServices>();

            // Dependencia de Roles
            services.AddScoped<IRolServices, RolService>();

            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}

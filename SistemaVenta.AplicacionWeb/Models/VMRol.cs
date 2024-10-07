using SistemaVenta.Entity;

namespace SistemaVenta.AplicacionWeb.Models
{
    // Se crean estas clases Vista de Modelo ya que no es buena 
    //practica trabajar directamente con los modelos

    // Es casi lo mismo que el modelo, pero solo se deben sacar 
    // los atributos que se van a necesitar
    public class VMRol
    {
        public int IdRol { get; set; }

        public string? Descripcion { get; set; }
    }
}

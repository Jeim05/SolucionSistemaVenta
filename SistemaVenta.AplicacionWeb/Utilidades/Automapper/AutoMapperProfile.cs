using SistemaVenta.AplicacionWeb.Models.ViewModels;
using SistemaVenta.Entity;
using System.Globalization;
using AutoMapper;

namespace SistemaVenta.AplicacionWeb.Utilidades.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, VMRol>().ReverseMap();
            #endregion Rol

            #region Usuario
            // Conversion de Usuario a ViewModelUsuario
            CreateMap<Usuario, VMUsuario>()
            .ForMember(destino =>
               destino.EsActivo,
               opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
               )
            .ForMember(destino =>
            destino.NombreRol,
            opt => opt.MapFrom(origen => origen.IdRolNavigation.Descripcion));

            // Conversion de ViewModelUsuario a Usuario
            CreateMap<VMUsuario, Usuario>().ForMember(destino =>
            destino.EsActivo,
            opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
            )
                .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
                );

            #endregion

            #region Negocio
            CreateMap<Negocio, VMNegocio>()
              .ForMember(destino =>
                destino.PorcentajeImpuesto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.PorcentajeImpuesto.Value, new CultureInfo("es-CR")))
                );

            CreateMap<VMNegocio, Negocio>()
               .ForMember(destino =>
               destino.PorcentajeImpuesto,
               opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PorcentajeImpuesto, new CultureInfo("es-CR")))
               );
            #endregion

            #region Categoria

            #endregion
        }
    }
}

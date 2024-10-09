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
            CreateMap<Categoria, VmCategoria>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<VmCategoria, Categoria>()
              .ForMember(destino =>
              destino.EsActivo,
              opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
              );
            #endregion

            #region PRODUCTO
            CreateMap<Producto, VMProducto>()
             .ForMember(destino =>
              destino.EsActivo,
              opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
              )
             .ForMember(destino =>
               destino.NombreCategoria,
              opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Descripcion)
              )
             .ForMember(destino =>
                 destino.Precio,
                 opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-CR")))
              );

            CreateMap<VMProducto, Producto>()
             .ForMember(destino =>
              destino.EsActivo,
              opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
              )
             .ForMember(destino =>
               destino.IdCategoriaNavigation,
              opt => opt.Ignore()
              )
             .ForMember(destino =>
                 destino.Precio,
                 opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-CR")))
              );
            #endregion

            #region TipoDocuemnto
            CreateMap<TipoDocumentoVenta, VMTipoDocumentoVenta>().ReverseMap();
            #endregion

            #region Venta 
            CreateMap<Venta, VMVenta>()
             .ForMember(destino =>
              destino.TipoDocumentoVenta,
              opt => opt.MapFrom(origen => origen.IdTipoDocumentoVentaNavigation.Descripcion)
              )
             .ForMember(destino =>
              destino.Usuario,
              opt => opt.MapFrom(origen => origen.IdUsuarioNavigation.Nombre)
              )
             .ForMember(destino =>
              destino.SubTotal,
              opt => opt.MapFrom(origen => Convert.ToString(origen.SubTotal.Value, new CultureInfo("es-CR")))
              )
             .ForMember(destino =>
              destino.ImpuestoTotal,
              opt => opt.MapFrom(origen => Convert.ToString(origen.ImpuestoTotal.Value, new CultureInfo("es-CR")))
              )
             .ForMember(destino =>
              destino.Total,
              opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-CR")))
              )
             .ForMember(destino =>
              destino.FechaRegistro,
              opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
              );

            CreateMap<VMVenta, Venta>()
            .ForMember(destino =>
             destino.SubTotal,
             opt => opt.MapFrom(origen => Convert.ToDecimal(origen.SubTotal, new CultureInfo("es-CR")))
             )
            .ForMember(destino =>
             destino.ImpuestoTotal,
             opt => opt.MapFrom(origen => Convert.ToDecimal(origen.ImpuestoTotal, new CultureInfo("es-CR")))
             )
            .ForMember(destino =>
             destino.Total,
             opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Total, new CultureInfo("es-CR")))
             );


            #endregion
        }
    }
}

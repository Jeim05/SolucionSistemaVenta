using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Newtonsoft.Json;
using SistemaVenta.AplicacionWeb.Models.ViewModels;
using SistemaVenta.AplicacionWeb.Utilidades;
using SistemaVenta.Entity;
using SistemaVenta.BLL.Interfaces;

namespace SistemaVenta.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRolServices _rolServices;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IRolServices rolServices, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _rolServices = rolServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListaRoles()
        {
            List<VMRol> vmListaRoles = _mapper.Map<List<VMRol>>(await _rolServices.Lista()); // convierte la lista
            return StatusCode(StatusCodes.Status200OK, vmListaRoles);
        }
    }
}

using Dominio.DTO;
using Dominio.Entidad;
using Dominio.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIK11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Obtiene una lista de usuarios paginada.
        /// </summary>
        /// <param name="numeroPagina">Número de página para la paginación.</param>
        /// <remarks>
        /// Aplicación destino:
        /// - App móvil de gestión de usuarios
        /// Vistas: 
        /// - C.001, C.002
        /// </remarks>
        /// <returns>Una lista de usuarios paginada.</returns>
        [HttpGet()]
        public IEnumerable<User> GetUsers(int numeroPagina)
        {
            return _userService.GetUsers(numeroPagina);
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a recuperar.</param>
        /// <returns>El usuario correspondiente al ID proporcionado.</returns>
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetUserById(id);    
        }


        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">Datos del usuario a crear.</param>
        [HttpPost]
        public void Post([FromBody] UsuarioDTO user)
        {
            _userService.CreateUser(user);

        }

    
        /// <summary>
        /// Actualiza un usuario existente por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a actualizar.</param>
        /// <param name="user">Datos actualizados del usuario.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsuarioDTO user)
        {
            _userService.UpdateUser(id,user);
        }

    }
}

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
        // GET: api/<UserController>
        [HttpGet()]
        public IEnumerable<User> GetUsers(int numeroPagina)
        {
            return _userService.GetUsers(numeroPagina);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetUserById(id);    
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UsuarioDTO user)
        {
            _userService.CreateUser(user);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsuarioDTO user)
        {
            _userService.UpdateUser(id,user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

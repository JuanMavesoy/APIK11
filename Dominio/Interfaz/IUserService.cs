using Dominio.DTO;
using Dominio.Entidad;

namespace Dominio.Interfaz
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(int numPage);

        User GetUserById(int id);
        void CreateUser(UsuarioDTO user);
        void UpdateUser(int id, UsuarioDTO user);
    }
}

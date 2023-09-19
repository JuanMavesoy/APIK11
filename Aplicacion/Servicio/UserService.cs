using Aplicacion.Exceptions;
using Aplicacion.Validators;
using Dominio.DTO;
using Dominio.Entidad;
using Dominio.Interfaz;

namespace Aplicacion.Servicio
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(UsuarioDTO user)
        {
            string errorString = "";
            var validator = new UsuarioValidator();
            var resultado = validator.Validate(user);

            if (resultado.IsValid)
            {
                var usuario = new User()
                {
                    first_name = user.first_name,
                    last_name = user.last_name,
                    email = user.email, 
                    avatar = user.avatar,
                };
                _unitOfWork.Repository<User>().Insert(usuario);
                _unitOfWork.Commit();
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    errorString = errorString + $"Error: {error.ErrorMessage}";
                }
               throw new AppException($"{errorString}");
            }

        }

        public User GetUserById(int id)
        {
            var user = _unitOfWork.Repository<User>().GetByID(id);
            return user;
        }

        public IEnumerable<User> GetUsers(int numPage)
        {
            var users = _unitOfWork.Repository<User>().Get(page: numPage, pageSize: 5);
            return users;

        }

        public void UpdateUser(int id, UsuarioDTO user)
        {
            var usuario = _unitOfWork.Repository<User>().GetByID(id);

            usuario.first_name = user.first_name;
            usuario.last_name = user.last_name; 
            usuario.email = user.email;
            usuario.avatar = user.avatar;

            _unitOfWork.Repository<User>().Update(usuario);
            _unitOfWork.Commit();
        }
    }
}
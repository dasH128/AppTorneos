using Parcial.Domain;
using Parcial.Repository.Dto;

namespace Parcial.Repository
{
    public interface IJugadorRepository: IRepository<Jugador>
    {
        bool EmailExist(string email);
        UsuarioDto Login(string correo, string password);
    }
}
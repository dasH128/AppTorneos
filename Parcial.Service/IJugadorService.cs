using Parcial.Domain;
using Parcial.Repository.Dto;

namespace Parcial.Service
{
    public interface IJugadorService: IService<Jugador>
    {
        bool EmailExist(string email);
        UsuarioDto Login(string correo, string password);
    }
}
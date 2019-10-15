using System.Collections.Generic;
using Parcial.Domain;
using Parcial.Repository;
using Parcial.Repository.Dto;

namespace Parcial.Service.Implementation
{
    public class JugadorService : IJugadorService
    {
        private IJugadorRepository jugadorRepository;

        public JugadorService(IJugadorRepository jugadorRepository){
            this.jugadorRepository = jugadorRepository;
        }
        public bool Create(Jugador entity){
            return jugadorRepository.Create(entity);
        }


        public bool Delete(int id){
            return jugadorRepository.Delete(id);
        }

        public bool EmailExist(string email){
            return jugadorRepository.EmailExist(email);
        }

        public IEnumerable<Jugador> FindAll(){
           return jugadorRepository.FindAll();
        }

        public Jugador FindByID(int id){
            return jugadorRepository.FindByID(id);
        }

        public UsuarioDto Login(string correo, string password){
            return jugadorRepository.Login(correo, password);
        }

        public bool Update(Jugador entity){
            return jugadorRepository.Update(entity);
        }
    }
}
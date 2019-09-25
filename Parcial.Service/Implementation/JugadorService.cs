using System.Collections.Generic;
using Parcial.Domain;
using Parcial.Repository;

namespace Parcial.Service.Implementation
{
    public class JugadorService : IJugadorService
    {
        private IJugadorRepository jugadorRepository;

        public JugadorService(IJugadorRepository jugadorRepository){
            this.jugadorRepository = jugadorRepository;
        }
        public bool Create(Jugador entity)
        {
            return jugadorRepository.Create(entity);
        }

        public bool Delete(int id)
        {
            return jugadorRepository.Delete(id);
        }

        public IEnumerable<Jugador> FindAll()
        {
           return jugadorRepository.FindAll();
        }

        public Jugador FindByID(int id)
        {
            return jugadorRepository.FindByID(id);
        }

        public bool Update(Jugador entity)
        {
            return jugadorRepository.Update(entity);
        }
    }
}
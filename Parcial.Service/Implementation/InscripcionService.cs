using System.Collections.Generic;
using Parcial.Domain;
using Parcial.Repository;

namespace Parcial.Service.Implementation
{
    public class InscripcionService : IInscripcionService
    {
        private IInscripcionRepository inscripcionRepository;

        public InscripcionService(IInscripcionRepository inscripcionRepository){
            this.inscripcionRepository=inscripcionRepository;
        }
        public bool Create(Inscripcion entity)
        {
            return inscripcionRepository.Create(entity);
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Inscripcion> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Inscripcion FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Inscripcion entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
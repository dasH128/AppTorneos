using System.Collections.Generic;
using Parcial.Domain;
using Parcial.Repository;

namespace Parcial.Service.Implementation
{
    public class TorneoService : ITorneoService
    {
        private ITorneoRepository torneoRepository;

        public TorneoService(ITorneoRepository torneoRepository){
            this.torneoRepository = torneoRepository;
        }
        public bool Create(Torneo entity)
        {
          return torneoRepository.Create(entity);
        }

        public bool Delete(int id)
        {
           return torneoRepository.Delete(id);
        }

        public IEnumerable<Torneo> FindAll()
        {
           return torneoRepository.FindAll();
        }

        public Torneo FindByID(int id)
        {
            return torneoRepository.FindByID(id);
        }

        public bool Update(Torneo entity)
        {
            return torneoRepository.Update(entity);
        }
    }
}
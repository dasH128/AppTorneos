using System.Collections.Generic;
using System.Linq;
using Parcial.Domain;

namespace Parcial.Repository.Implementation
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private ApplicationDbContext context;

        public InscripcionRepository(ApplicationDbContext context){
            this.context = context;
        }
        public bool Create(Inscripcion entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
                return true;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Inscripcion> FindAll()
        {
            var result = new List<Inscripcion>();
            try
            {
                result = context.Inscripciones.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public Inscripcion FindByID(int id)
        {
           var result = new Inscripcion();
           try
           {
               result = context.Inscripciones.Single(x=>x.Id == id);
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return result;
        }

        public bool Update(Inscripcion entity)
        {
           throw new System.NotImplementedException();
        }
    }
}
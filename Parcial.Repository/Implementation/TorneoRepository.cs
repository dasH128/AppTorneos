using System.Collections.Generic;
using System.Linq;
using Parcial.Domain;

namespace Parcial.Repository.Implementation
{
    public class TorneoRepository : ITorneoRepository
    {

        private ApplicationDbContext context;

        public TorneoRepository(ApplicationDbContext context){
            this.context=context;
        }
        public bool Create(Torneo entity)
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

        public IEnumerable<Torneo> FindAll()
        {
            var result = new List<Torneo>();
            try
            {
                result = context.Torneos.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public Torneo FindByID(int id)
        {
            var result = new Torneo();
            try
            {
                result = context.Torneos.Single(x=>x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Update(Torneo entity)
        {
           try
           {
               var torneoOrigina = context.Torneos.Single(
                   x=>x.Id == entity.Id
               );

               torneoOrigina.Id = entity.Id;
               torneoOrigina.Nombre = entity.Nombre;
               torneoOrigina.Descripcion = entity.Descripcion;
               torneoOrigina.FechaFin = entity.FechaFin;
               torneoOrigina.FechaInic = torneoOrigina.FechaInic;
               torneoOrigina.NombreJuego = entity.NombreJuego;
               torneoOrigina.Premio = entity.Premio;

               context.Update(torneoOrigina);
               context.SaveChanges();


           }
           catch (System.Exception)
           {
               
               return false;;
           }
           return true;
        }
    }
}
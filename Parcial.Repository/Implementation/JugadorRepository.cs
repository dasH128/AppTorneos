using System.Collections.Generic;
using System.Linq;
using Parcial.Domain;

namespace Parcial.Repository.Implementation
{
    public class JugadorRepository : IJugadorRepository
    {
        private ApplicationDbContext context;

        public JugadorRepository(ApplicationDbContext context){
            this.context = context;
        }
        public bool Create(Jugador entity)
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

        public IEnumerable<Jugador> FindAll()
        {
            var result = new List<Jugador>();
            try
            {
                result = context.Jugadores.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public Jugador FindByID(int id)
        {
           var result = new Jugador();
           try
           {
               result = context.Jugadores.Single(x=> x.Id == id);
           }
           catch (System.Exception)
           {
               
               throw;
           }
           return result;
        }

        public bool Update(Jugador entity)
        {
            try
            {
                var jugadorOrigina = context.Jugadores.Single(
                    x=>x.Id == entity.Id
                );

                jugadorOrigina.Id = entity.Id;
                jugadorOrigina.Nombre = entity.Nombre;
                jugadorOrigina.Apellido = entity.Apellido;
                jugadorOrigina.Edad = entity.Edad;
                jugadorOrigina.Nickname = entity.Nickname;

                context.Update(jugadorOrigina);
                context.SaveChanges();

            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }
    }
}
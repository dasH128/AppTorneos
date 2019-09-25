using Microsoft.EntityFrameworkCore;
using Parcial.Domain;

namespace Parcial.Repository
{
    public class ApplicationDbContext: DbContext 
    {
        public DbSet<Jugador>Jugadores{get; set;}

        public DbSet<Torneo>Torneos{get;set;}

        public DbSet<Inscripcion>Inscripciones{get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
    }
}
using System;

namespace Parcial.Domain
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInic { get; set; }
        public DateTime FechaFin { get; set; }
        public string NombreJuego { get; set; }
        public int Premio { get; set; }
        
    }
}
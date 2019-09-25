namespace Parcial.Domain
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int Puesto { get; set; }

        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; }

        public int JugadorId { get; set; }
        public Jugador Jugador  { get; set; }
    }
}
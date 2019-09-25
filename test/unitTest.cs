using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Parcial.Domain
{
    public class unitTest
    {
         public void Test_Registrarjugador(){

            Jugador jugador = new Jugador {
                Nombre = "dash",
                Apellido = "tennyson",
                Nickname = "trash",
                Edad = "22"
            };

            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Save(jugador)).Returns(true);

            var resul = mock.Object.Save(jugador);
            Assert.True(resul);
        }

        [Fact]
        public void Test_ListarJugador(){
            var listOfJugador = new List<Jugador>
            {
                new Jugador
                {
                     Nombre = "dash",
                    Apellido = "tennyson",
                    Nickname = "trash",
                    Edad = "22"
                }
            };
            Jugador jugador = new Jugador();

            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.FindAll()).Returns(listOfJugador);
            var result = mock.Object.FindAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_UpadteJugador(){
            Jugador jugador = new Jugador
            {
                 Nombre = "dash",
                 Apellido = "tennyson",
                 Nickname = "trash",
                 Edad = "22"
            };
            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Update(jugador)).Returns(true);
            var resultado = mock.Object.Update(jugador);
            Assert.True(resultado);
        }

        [Fact]
        public void Test_EliminarJugador(){
            Jugador jugador = new Jugador
            {
                 Nombre = "dash",
                 Apellido = "tennyson",
                 Nickname = "trash",
                 Edad = "22"
            };
            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Delete(jugador)).Returns(true);
            var result = mock.Object.Delete(jugador);
            Assert.True(result);
        }

         public void Test_Registrartorneo(){

            Torneo torneo = new Torneo {
                Nombre = "del poder",
                Descripcion = "univ 6 vs univ 7",
                FechaInic = "2015-08-22T03:28:07.116Z",
                FechaFin = "2015-08-22T03:28:07.116Z",
                NombreJuego = "Dragon Ball fighterz",
                Premio = "7"
                
            };

            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.Save(torneo)).Returns(true);

            var resul = mock.Object.Save(torneo);
            Assert.True(resul);
        }

        [Fact]
        public void Test_ListarTorneo(){
            var listOfTorneo = new List<Torneo>
            {
                new Torneo
                {
                    Nombre = "del poder",
                    Descripcion = "univ 6 vs univ 7",
                    FechaInic = "2015-08-22T03:28:07.116Z",
                    FechaFin = "2015-08-22T03:28:07.116Z",
                    NombreJuego = "Dragon Ball fighterz",
                    Premio = "7"
                }
            };
            Torneo torneo = new Torneo();

            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.FindAll()).Returns(listOfTorneo);
            var result = mock.Object.FindAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Upadtetorneo(){
            Torneo torneo = new Torneo
            {
                Nombre = "del poder",
                Descripcion = "univ 6 vs univ 7",
                FechaInic = "2015-08-22T03:28:07.116Z",
                FechaFin = "2015-08-22T03:28:07.116Z",
                NombreJuego = "Dragon Ball fighterz",
                Premio = "7"
            };
            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.Update(torneo)).Returns(true);
            var resultado = mock.Object.Update(torneo);
            Assert.True(resultado);
        }

        [Fact]
        public void Test_EliminarTorneo(){
            Jugador jugador = new Jugador
            {
               Nombre = "del poder",
                Descripcion = "univ 6 vs univ 7",
                FechaInic = "2015-08-22T03:28:07.116Z",
                FechaFin = "2015-08-22T03:28:07.116Z",
                NombreJuego = "Dragon Ball fighterz",
                Premio = "7"
            };
            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Delete(jugador)).Returns(true);
            var result = mock.Object.Delete(jugador);
            Assert.True(result);
        }

            public void Test_RegistrarInscripcion(){

                Inscripcion inscripcion = new Inscripcion {
                puesto = "500",
                torneoid = "1",
                jugadorid = "1"               
                
            };

            var mock = new Mock<IInscripcionRepository>();
            mock.Setup(x => x.Save(inscripcion)).Returns(true);

            var resul = mock.Object.Save(inscripcion);
            Assert.True(resul);
        }


    }
}
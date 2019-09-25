using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using Parcial.Domain;
using Parcial.Repository;

namespace Parcial.Test.Unitarias
{
    public class unitTestJugador
    {
        private IJugadorRepository jugadorRepository;

        [Fact]
        public void TestCreateJugador(){
            Jugador jugador = new Jugador {
                Nombre = "dash",
                Apellido = "tennyson",
                Nickname = "El Dios",
                Edad = 22
            };

            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Create(jugador)).Returns(true);

            var resul = mock.Object.Create(jugador);
            Assert.True(resul);
        }

        [Fact]
        public void TestUpdateJugador(){
            Jugador jugador = new Jugador
            {
                 Nombre = "Pablita",
                 Apellido = "Ratamaru",
                 Nickname = "gilazo1",
                 Edad = 22
            };
            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Update(jugador)).Returns(true);
            var resultado = mock.Object.Update(jugador);
            Assert.True(resultado);
        }

        [Fact]
        public void TestDeleteJugador(){
            Jugador jugador = new Jugador
            {
                Id = 5,   
                 Nombre = "dash",
                 Apellido = "tennyson",
                 Nickname = "trash",
                 Edad = 22
            };
            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.Delete(jugador.Id)).Returns(true);
            var result = mock.Object.Delete(jugador.Id);
            Assert.True(result);
        }

        [Fact]
        public void TestFindAllJugador(){
            var listOfJugador = new List<Jugador>
            {
                new Jugador
                {
                     Nombre = "Fernanda",
                    Apellido = "Cabrera",
                    Nickname = "Lokita",
                    Edad = 22
                }
            };
            Jugador jugador = new Jugador();

            var mock = new Mock<IJugadorRepository>();
            mock.Setup(x => x.FindAll()).Returns(listOfJugador);
            var result = mock.Object.FindAll();
            Assert.NotNull(result);
        }

    }
}
using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using Parcial.Domain;
using Parcial.Repository;

namespace Parcial.Test.Unitarias
{
    public class unitTestTorneo
    {
        [Fact]
        public void TestCreateTorneo(){
            Torneo torneo = new Torneo {
                Nombre = "del poder",
                Descripcion = "univ 6 vs univ 7",
                FechaInic = DateTime.Parse("2015-08-22T03:28:07.116Z"),
                FechaFin = DateTime.Parse("2015-08-25T03:28:07.116Z"),
                NombreJuego = "Dragon Ball fighterz",
                Premio = 700
                
            };

            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.Create(torneo)).Returns(true);

            var resul = mock.Object.Create(torneo);
            Assert.True(resul);
        }

        [Fact]
        public void TestUpdateTorneo(){
            Torneo torneo = new Torneo
            {
                Nombre = "del poder",
                Descripcion = "univ 6 vs univ 7",
                FechaInic = DateTime.Parse("2015-08-22T03:28:07.116Z"),
                FechaFin = DateTime.Parse("2015-08-25T03:28:07.116Z"),
                NombreJuego = "Dragon Ball fighterz",
                Premio = 700
            };
            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.Update(torneo)).Returns(true);
            var resultado = mock.Object.Update(torneo);
            Assert.True(resultado);
        }

        [Fact]
        public void TestDeleteTorneo(){
            Torneo torneo = new Torneo
            {
                Id = 5,
               Nombre = "del poder",
                Descripcion = "univ 6 vs univ 7",
                FechaInic = DateTime.Parse("2015-08-22T03:28:07.116Z"),
                FechaFin = DateTime.Parse("2015-08-25T03:28:07.116Z"),
                NombreJuego = "Dragon Ball fighterz",
                Premio = 700
            };
            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.Delete(torneo.Id)).Returns(true);
            var result = mock.Object.Delete(torneo.Id);
            Assert.True(result);
        }

        [Fact]
        public void TestFindAllTorneo(){
            var listOfTorneo = new List<Torneo>
            {
                new Torneo
                {
                    Nombre = "del poder",
                    Descripcion = "univ 6 vs univ 7",
                    FechaInic = DateTime.Parse("2015-08-22T03:28:07.116Z"),
                    FechaFin = DateTime.Parse("2015-08-25T03:28:07.116Z"),
                    NombreJuego = "Dragon Ball fighterz",
                    Premio = 700
                }
            };
            Torneo torneo = new Torneo();

            var mock = new Mock<ITorneoRepository>();
            mock.Setup(x => x.FindAll()).Returns(listOfTorneo);
            var result = mock.Object.FindAll();
            Assert.NotNull(result);
        }
    }
}
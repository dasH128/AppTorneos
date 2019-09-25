using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using Parcial.Domain;
using Parcial.Repository;

namespace Parcial.Test.Unitarias
{
    public class unitTestInscripcion
    {
        
        [Fact]
        public void TestCreateInscripcion(){
            Inscripcion inscripcion = new Inscripcion {
                Puesto = 0,
                TorneoId = 1,
                JugadorId = 1               
            };
            var mock = new Mock<IInscripcionRepository>();
            mock.Setup(x => x.Create(inscripcion)).Returns(true);

            var resul = mock.Object.Create(inscripcion);
            Assert.True(resul);
        }
    }
}
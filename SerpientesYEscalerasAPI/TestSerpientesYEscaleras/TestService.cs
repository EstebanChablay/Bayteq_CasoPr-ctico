using SerpientesYEscalerasAPI.Modelo;
using SerpientesYEscalerasAPI.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSerpientesYEscaleras
{
    public class TestService
    {
        private readonly JuegoService _service;
        private readonly Tablero _tablero = new Tablero();

        public TestService()
        {
            _service = new JuegoService(_tablero);
        }

        [Fact]
        public void TestCrearJugador()
        {
            string nombre = "Esteban";

            var jugador = _service.CrearJugador(nombre);

            Assert.Equal(nombre, jugador.Nombre);
            Assert.Equal(1, jugador.Posicion);
        }


        [Theory]
        [InlineData(100, true)]
        [InlineData(102, false)]
        [InlineData(99, false)]
        [InlineData(97, false)]
        public void TestVerificarGanador(int posicion, bool resultadoEsperado)
        {
            var jugador = new Jugador { Nombre = "Esteban", Posicion = posicion };

            bool resultado = _service.VerificarGanador(jugador);

            Assert.Equal(resultadoEsperado, resultado);
        }

    }
}

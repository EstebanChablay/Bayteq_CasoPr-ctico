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


        //Validar que al Crear el jugador inicio en la Posicion 1 y que no sea Null
        [Fact]
        public void TestCrearJugador()
        {
            string nombre = "Esteban";

            var jugador = _service.CrearJugador(nombre);

            Assert.NotNull(jugador);
            Assert.Equal(nombre, jugador.Nombre);
            Assert.Equal(1, jugador.Posicion);
        }

        //Validar que solo gana si llega a la casilla 100, si se pasa o le falta no gana
        //UAT1 y UAT2
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

        //Validar que si supera el casillero 100 vuelve al casillero en el que estaba
        [Theory]
        [InlineData(96, 96)]
        [InlineData(98, 98)]
        [InlineData(80, 86)]
        [InlineData(94, 100)]
        public void TestJugadorNoSupera100(int posInicial, int posFinal)
        {
            var jugador = new Jugador { Nombre = "Esteban", Posicion = posInicial };
            int lanzamiento = 6;

            int resultado = _service.MoverJugadorPredefinido(jugador, lanzamiento);

            Assert.Equal(posFinal, jugador.Posicion);
        }

        //Validar el movimiento de la ficha UAT2 y UAT3
        [Theory]
        [InlineData(1,3,4)]
        [InlineData(4,4,31)] //Aqui se va a la casilla 8 la cual tiene escalera hacia el 31
        public void TestValidarMovimiento(int posInicial, int lanzamiento, int posFinal)
        {
            var jugador = new Jugador { Nombre = "Esteban", Posicion = posInicial };


            int resultado = _service.MoverJugadorPredefinido(jugador, lanzamiento);

            Assert.Equal(posFinal, resultado);
        }

    }
}

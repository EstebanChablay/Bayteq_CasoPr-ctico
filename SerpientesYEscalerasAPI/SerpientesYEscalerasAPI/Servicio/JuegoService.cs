using SerpientesYEscalerasAPI.Modelo;

namespace SerpientesYEscalerasAPI.Servicio
{
    public class JuegoService : IJuegoService
    {
        private readonly Tablero _tablero;
        private readonly Dado _dado;

        public JuegoService(Tablero tablero)
        {
            _tablero = tablero;
            _dado = new Dado();
        }

        public Jugador CrearJugador(string nombre)
        {
            return new Jugador { Nombre = nombre };
        }

        public void LanzarDado(Jugador jugador)
        {
            if (jugador.Posicion == 100)
                throw new InvalidOperationException("El jugador ya ha ganado.");

            jugador.UltimoLanzamiento = _dado.Lanzar();
        }

        public int MoverJugador(Jugador jugador)
        {
            int lanzamiento = jugador.UltimoLanzamiento;
            int antiguaPosicion = jugador.Posicion;
            int nuevaPosicion = jugador.Posicion + lanzamiento;

            if (nuevaPosicion > 100)
            {
                nuevaPosicion = antiguaPosicion;
            }

            jugador.Posicion = _tablero.VerificarSerpienteOEscalera(nuevaPosicion);
            return jugador.Posicion;
        }

        //Aplico la misma logica de la anterior funcion pero con un valor definido en el lanzamiento para los test
        public int MoverJugadorPredefinido(Jugador jugador, int lanzamiento)
        {
            int antiguaPosicion = jugador.Posicion;
            int nuevaPosicion = jugador.Posicion + lanzamiento;

            if (nuevaPosicion > 100)
            {
                nuevaPosicion = antiguaPosicion;
            }

            jugador.Posicion = _tablero.VerificarSerpienteOEscalera(nuevaPosicion);
            return jugador.Posicion;
        }

        public bool VerificarGanador(Jugador jugador)
        {
            return jugador.Posicion == 100;
        }

    }
}

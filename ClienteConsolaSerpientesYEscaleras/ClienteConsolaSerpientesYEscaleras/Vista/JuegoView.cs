using ClienteConsolaSerpientesYEscaleras.Controlador;
using ClienteConsolaSerpientesYEscaleras.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsolaSerpientesYEscaleras.Vista
{
    public class JuegoView
    {
        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public void MostrarJugador(Jugador jugador)
        {
            Console.WriteLine($"Jugador: {jugador.Nombre} | Posición: {jugador.Posicion} | Último Lanzamiento: {jugador.UltimoLanzamiento}");
        }

        public void MostrarResultadoMovimiento(int nuevaPosicion, bool haGanado, int ultimoLanzamiento)
        {
            Console.WriteLine($"\nResultado del Dado: {ultimoLanzamiento} | Posición actual: {nuevaPosicion} ");
            if (haGanado)
            {
                Console.WriteLine($"¡Felicidades! El jugador Has ganado el juego.");
                Environment.Exit(0);
            }
                
        }
    }
}

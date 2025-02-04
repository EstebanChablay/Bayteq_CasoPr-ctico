using SerpientesYEscalerasAPI.Modelo;

namespace SerpientesYEscalerasAPI.Servicio
{
    public interface IJuegoService
    {
        Jugador CrearJugador(string nombre);
        void LanzarDado(Jugador jugador);
        int MoverJugador(Jugador jugador);
        bool VerificarGanador(Jugador jugador);
    }
}

using Microsoft.AspNetCore.Mvc;
using SerpientesYEscalerasAPI.Modelo;
using SerpientesYEscalerasAPI.Servicio;

namespace SerpientesYEscalerasAPI.Controlador
{
    [ApiController]
    [Route("api/bayteq")]
    public class JuegoController : ControllerBase
    {
        private readonly IJuegoService _juegoService;
        private static readonly Dictionary<string, Jugador> _jugadores = new();

        public JuegoController(IJuegoService juegoService)
        {
            _juegoService = juegoService;
        }

        [HttpPost("crear_jugador")]
        public IActionResult CrearJugador([FromBody] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest("No se ingreso ningun nombre");
            }
            if (_jugadores.ContainsKey(nombre))
            {
                return Conflict("El jugador ya existe");
            }

            var jugador = _juegoService.CrearJugador(nombre);
            _jugadores[nombre] = jugador;
            return Ok(jugador);
        }

        [HttpPost("mover_jugador")]
        public IActionResult MoverJugador([FromBody] string nombre)
        {
            if (!_jugadores.ContainsKey(nombre))
                return NotFound("Jugador no encontrado :c");

            var jugador = _jugadores[nombre];
            _juegoService.LanzarDado(jugador);
            int lanzamiento = jugador.UltimoLanzamiento;
            int nuevaPosicion = _juegoService.MoverJugador(jugador);
            bool haGanado = _juegoService.VerificarGanador(jugador);

            return Ok(new { nuevaPosicion, haGanado, ultimoLanzamiento = lanzamiento });

        }

        [HttpGet("obtener_jugador/{nombre}")]
        public IActionResult obtenerJugador(string nombre)
        {
            if (!_jugadores.ContainsKey(nombre))
                return NotFound("Jugador no encontrado:c");

            var jugador = _jugadores[nombre];

            return Ok(new { 
                nombre = jugador.Nombre,
                posicion = jugador.Posicion,
                ultimoLanzamiento = jugador.UltimoLanzamiento
            });
        }

        [HttpPost("reiniciar_juego")]
        public IActionResult ReiniciarJuego()
        {
            _jugadores.Clear();
            return Ok("Juego reiniciado exitosamente.");
        }


    }
}

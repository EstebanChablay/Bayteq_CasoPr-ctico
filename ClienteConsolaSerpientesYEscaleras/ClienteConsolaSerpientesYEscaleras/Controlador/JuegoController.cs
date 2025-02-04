using ClienteConsolaSerpientesYEscaleras.Modelo;
using ClienteConsolaSerpientesYEscaleras.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClienteConsolaSerpientesYEscaleras.Controlador
{
    public class JuegoController
    {
        private readonly HttpClient _httpClient;
        private readonly JuegoView _view;
        private const string baseUrl = "http://localhost:5215/api/bayteq/";

        public JuegoController()
        {
            _httpClient = new HttpClient();
            _view = new JuegoView();
        }

        public async Task CrearJugador(string nombre)
        {
            var content = new StringContent($"\"{nombre}\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(baseUrl + "crear_jugador", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var jugador = JsonSerializer.Deserialize<Jugador>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _view.MostrarJugador(jugador);
            }
            else
            {
                _view.MostrarMensaje($"Error: {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task MoverJugador(string nombre)
        {
            var content = new StringContent($"\"{nombre}\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(baseUrl + "mover_jugador", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonSerializer.Deserialize<dynamic>(json);
                _view.MostrarResultadoMovimiento(
                    (int)resultado.GetProperty("nuevaPosicion").GetInt32(),
                    (bool)resultado.GetProperty("haGanado").GetBoolean(),
                    (int)resultado.GetProperty("ultimoLanzamiento").GetInt32()
                );
            }
            else
            {
                _view.MostrarMensaje($"Error: {await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}

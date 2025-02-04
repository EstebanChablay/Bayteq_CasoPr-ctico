import axios from "axios";

const API_URL = "http://localhost:5215/api/bayteq";

export const crearJugador = async (nombre) => {
  try {
    const response = await axios.post(`${API_URL}/crear_jugador`, nombre, {
      headers: { "Content-Type": "application/json" },
    });
    return response.data;
  } catch (error) {
    console.error("Error al crear jugador:", error.response?.data || error);
    return null;
  }
};

export const moverJugador = async (nombre) => {
  try {
    const response = await axios.post(`${API_URL}/mover_jugador`, nombre, {
      headers: { "Content-Type": "application/json" },
    });
    return response.data;
  } catch (error) {
    console.error("Error al mover jugador:", error.response?.data || error);
    return null;
  }
};

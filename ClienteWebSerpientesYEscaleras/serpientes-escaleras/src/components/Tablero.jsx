import React, { useState } from "react";
import { crearJugador, moverJugador } from "../api/juegoApi";
import tableroImg from "../assets/tablero.png";
import "../styles/Tablero.css";

const Tablero = () => {
    const [nombre1, setNombre1] = useState("");
    const [nombre2, setNombre2] = useState("");
    const [jugador1, setJugador1] = useState(null);
    const [jugador2, setJugador2] = useState(null);
    const [turno, setTurno] = useState(1);
    const [mensaje, setMensaje] = useState("");

    const iniciarJuego = async () => {
        if (!nombre1 || !nombre2) {
            setMensaje("Debes ingresar los nombres de ambos jugadores.");
            return;
        }

        const j1 = await crearJugador(nombre1);
        const j2 = await crearJugador(nombre2);

        if (j1 && j2) {
            setJugador1(j1);
            setJugador2(j2);
            setMensaje(`¡Juego iniciado! Turno de ${nombre1}`);
        }
    };

    const jugarTurno = async () => {
        if (!jugador1 || !jugador2) return;

        const jugadorActual = turno === 1 ? jugador1.nombre : jugador2.nombre;
        const resultado = await moverJugador(jugadorActual);

        if (resultado) {
            if (turno === 1) {
                setJugador1((prev) => ({ ...prev, posicion: resultado.nuevaPosicion }));
            } else {
                setJugador2((prev) => ({ ...prev, posicion: resultado.nuevaPosicion }));
            }

            setMensaje(
                `${jugadorActual} lanzó un ${resultado.ultimoLanzamiento} y avanzó a la posición ${resultado.nuevaPosicion}`
            );

            if (resultado.haGanado) {
                setMensaje(`🎉 ¡${jugadorActual} ha ganado el juego! 🎉`);
            } else {
                setTurno(turno === 1 ? 2 : 1);
            }
        }
    };

    const jugadorHaGanado = (jugador) => jugador.posicion === 100;

    return (
        <div className="board-container">
            <h2>Caso Práctico | Serpientes y Escaleras</h2>
            <div className="tablero-container">
                <img src={tableroImg} alt="Tablero" className="tablero" />
                <div className="info-container">
                    {!jugador1 && !jugador2 && (
                        <div className="input-container">
                            <input
                                type="text"
                                placeholder="Nombre Jugador 1"
                                value={nombre1}
                                onChange={(e) => setNombre1(e.target.value)}
                            />
                            <input
                                type="text"
                                placeholder="Nombre Jugador 2"
                                value={nombre2}
                                onChange={(e) => setNombre2(e.target.value)}
                            />
                            <button onClick={iniciarJuego} className="boton-iniciar">
                                Iniciar Juego
                            </button>
                        </div>
                    )}

                    <h3 className="mensaje">{mensaje}</h3>

                    {jugador1 && jugador2 && (
                        <div className="player-info">
                            <p>{jugador1.nombre}: Casilla {jugador1.posicion}</p>
                            <p>{jugador2.nombre}: Casilla {jugador2.posicion}</p>
                            <button
                                onClick={jugarTurno}
                                className="boton-lanzar"
                                disabled={jugadorHaGanado(jugador1) || jugadorHaGanado(jugador2)}
                            >
                                Lanzar Dado (Turno de {turno === 1 ? jugador1.nombre : jugador2.nombre})
                            </button>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Tablero;
import React from "react";
import { motion } from "framer-motion";
import "../styles/Jugador.css";

const Jugador = ({ position, color }) => {
    return (
        <motion.div 
            className="jugador"
            style={{ backgroundColor: color, top: position.top, left: position.left }}
            animate={{ top: position.top, left: position.left }}
            transition={{ duration: 0.5 }}
        />
    );
};

export default Jugador;
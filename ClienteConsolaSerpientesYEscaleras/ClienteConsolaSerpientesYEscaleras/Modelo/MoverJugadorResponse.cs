using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsolaSerpientesYEscaleras.Modelo
{
    public class MoverJugadorResponse
    {
        public int NuevaPosicion { get; set; }
        public bool HaGanado {  get; set; }
        public int UltimoLanzamiento {  get; set; }
    }
}

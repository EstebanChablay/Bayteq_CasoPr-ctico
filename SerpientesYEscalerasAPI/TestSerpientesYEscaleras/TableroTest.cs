using SerpientesYEscalerasAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSerpientesYEscaleras
{
    public class TableroTest
    {
        private readonly Tablero _tablero;

        public TableroTest()
        {
            _tablero = new Tablero();
        }

        //Validar el funcionamiento de las serpientes
        [Theory]
        [InlineData(16, 6)]
        [InlineData(49, 11)]
        [InlineData(62, 19)]
        [InlineData(95, 75)]
        [InlineData(99, 80)]
        [InlineData(3, 3)]
        [InlineData(97, 97)]
        public void VerificarSerpienteOEscalera_PosFinal_Serpiente(int posInicial, int posFinal)
        {
            int resultado = _tablero.VerificarSerpienteOEscalera(posInicial);

            Assert.Equal(posFinal, resultado);
        }

        //validar el funcionamiento de las escaleras
        [Theory]
        [InlineData(2, 38)]
        [InlineData(7, 14)]
        [InlineData(21, 42)]
        [InlineData(78, 98)]
        [InlineData(87, 94)]
        [InlineData(3, 3)]
        [InlineData(97, 97)]
        public void VerificarSerpienteOEscalera_PosFinal_Escalera(int posInicial, int posFinal)
        {
            int resultado = _tablero.VerificarSerpienteOEscalera(posInicial);

            Assert.Equal(posFinal, resultado);
        }
    }
}

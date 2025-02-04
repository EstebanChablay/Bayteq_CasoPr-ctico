namespace SerpientesYEscalerasAPI.Modelo
{
    public class Tablero
    {
        public Dictionary<int, int> Serpientes { get; set; } = new Dictionary<int, int>
        {
            {16, 6}, {49, 11}, {46, 25}, {62, 19}, {64, 60}, 
            {74, 63}, {89, 68}, {95, 75}, {99, 80}, {92, 88}
        };

        public Dictionary<int, int> Escaleras { get; set; } = new Dictionary<int, int>
        {
            {2, 38}, {7, 14}, {8, 31}, {15, 26}, {21, 42},
            {28, 84}, {36, 44}, {51, 67}, {78, 98}, {87, 94}, {71, 91}
        };

        public int VerificarSerpienteOEscalera(int posicion)
        {
            if(Serpientes.ContainsKey(posicion))
                return Serpientes[posicion];
            if(Escaleras.ContainsKey(posicion))
                return Escaleras[posicion];
            return posicion;
        }
    }
}

namespace SerpientesYEscalerasAPI.Modelo
{
    public class Dado
    {
        private static readonly Random random = new Random();

        public int Lanzar()
        {
            return random.Next(1, 7);
        }
    }
}

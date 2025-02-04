using System.Threading.Tasks;
using ClienteConsolaSerpientesYEscaleras.Controlador;
using ClienteConsolaSerpientesYEscaleras.Vista;

class Program
{
    static async Task Main(string[] args)
    {
        var controlador = new JuegoController();
        List<string> jugadores = new List<string>();
        bool ganador = false;

        Console.WriteLine("||==================|| BIENVENIDO ||==================||");
        Console.WriteLine("Ingrese la cantidad de jugadores: ");
        int cantJugadores = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < cantJugadores; i++)
        {
            Console.WriteLine($"Ingrese el nombre del Jugador #{i+1}");
            string nombre = Console.ReadLine();
            jugadores.Add( nombre );
            await controlador.CrearJugador(jugadores[i]);
        }

        Console.WriteLine("\n|========================================================================|");
        Console.WriteLine("Lista de jugadores");
        for (int i = 0;i < jugadores.Count(); i++)
        {
            Console.WriteLine($"{i+1} - {jugadores[i]}");
        }

        while(true)
        {
            for (int i = 0; i < jugadores.Count(); i++)
            {
                Console.WriteLine("\n|========================================================================|");
                Console.WriteLine($"Turno del jugador #{i + 1} - {jugadores[i]}");
                Console.WriteLine("Presione Enter para lanzar el dado o escriba 'salir' para salir.");
                string input = Console.ReadLine();
                if (input.ToLower() == "salir")
                    break;

                await controlador.MoverJugador(jugadores[i]);
                Console.WriteLine("|========================================================================|\n");
            }
        }

    }
}
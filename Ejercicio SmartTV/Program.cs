using ConsoleApp3;
using System;
internal class Program
{
    static void Main(string[] args)
    {
        SmartTV tv = new SmartTV("Samsung", 55, true);

        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("=== SMART TV ===");
            Console.WriteLine(tv.CodigoConfig);
            Console.WriteLine($"Estado: {(tv.Encendido ? "ON" : "OFF")}");
            Console.WriteLine($"Canal: {tv.CanalActual}");
            Console.WriteLine($"Volumen: {tv.VolumenTexto}");

            Console.WriteLine();
            Console.WriteLine("1 - Power");
            Console.WriteLine("2 - Canal +1");
            Console.WriteLine("3 - Cambiar canal");
            Console.WriteLine("4 - Volumen +");
            Console.WriteLine("5 - Volumen -");
            Console.WriteLine("0 - Salir");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    tv.Power();
                    break;

                case 2:
                    tv.CambiarCanal();
                    break;

                case 3:
                    Console.Write("Canal: ");
                    int canal = int.Parse(Console.ReadLine());
                    tv.CambiarCanal(canal);
                    break;

                case 4:
                    tv.RegularVolumen(true);
                    break;

                case 5:
                    tv.RegularVolumen(false);
                    break;
            }

            Console.ReadLine();

        } while (opcion != 0);
    }
}
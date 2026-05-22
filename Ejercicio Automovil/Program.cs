using System;

namespace SimuladorAutomovil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            Console.Write("¿Caja automática? (s/n): ");
            bool cajaAutomatica = Console.ReadLine().ToLower() == "s";

            Automovil automovil = new Automovil(marca, cajaAutomatica);

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=== SIMULADOR AUTOMÓVIL ===");
                Console.WriteLine($"ID: {automovil.Identificador}");
                Console.WriteLine($"Motor: {(automovil.MotorEncendido ? "ON" : "OFF")}");
                Console.WriteLine($"Velocidad: {automovil.VelocidadActual} km/h");
                Console.WriteLine($"Modo crucero: {(automovil.ModoCrucero ? "ACTIVO" : "INACTIVO")}");

                Console.WriteLine();
                Console.WriteLine("1 - Encender/Apagar");
                Console.WriteLine("2 - Acelerar +10");
                Console.WriteLine("3 - Acelerar personalizado");
                Console.WriteLine("4 - Frenar total");
                Console.WriteLine("5 - Frenar personalizado");
                Console.WriteLine("6 - Activar crucero");
                Console.WriteLine("0 - Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        automovil.EncenderApagar();
                        break;

                    case 2:
                        automovil.Acelerar();
                        break;

                    case 3:
                        Console.Write("Km/h: ");
                        int acelerar = int.Parse(Console.ReadLine());
                        automovil.Acelerar(acelerar);
                        break;

                    case 4:
                        automovil.Frenar();
                        break;

                    case 5:
                        Console.Write("Km/h a reducir: ");
                        int frenar = int.Parse(Console.ReadLine());
                        automovil.Frenar(frenar);
                        break;

                    case 6:
                        automovil.ActivarModoCrucero();
                        break;
                }

                Console.WriteLine("Presione ENTER...");
                Console.ReadLine();

            } while (opcion != 0);
        }
    }
}
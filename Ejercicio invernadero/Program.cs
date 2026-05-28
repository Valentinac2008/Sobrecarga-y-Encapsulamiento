using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Invernadero sector1 = new Invernadero("Norte", "TROPICAL");

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== SIMULADOR DE INVERNADERO =====");
                Console.WriteLine();

                Console.WriteLine(sector1.ReporteEstado);

                Console.WriteLine($"Temperatura Actual: {sector1.TemperaturaActual} °C");
                Console.WriteLine($"Humedad del Suelo: {sector1.HumedadSuelo}%");
                Console.WriteLine($"Sistema de Riego: {(sector1.SistemaRiegoActivo ? "ACTIVO" : "INACTIVO")}");
                Console.WriteLine($"Calefacción: {(sector1.CalefaccionActiva ? "ACTIVA" : "INACTIVA")}");

                Console.WriteLine();
                Console.WriteLine("1 - Forzar clima manualmente");
                Console.WriteLine("2 - Simular paso del tiempo");
                Console.WriteLine("3 - Ejecutar control automático");
                Console.WriteLine("4 - Salir");

                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.Write("Ingrese nueva humedad: ");
                        int humedad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Ingrese nueva temperatura: ");
                        int temperatura = Convert.ToInt32(Console.ReadLine());

                        sector1.SimularClima(humedad, temperatura);

                        break;

                    case 2:


                        sector1.SimularClima();

                        Console.WriteLine("Paso del tiempo aplicado...");
                        break;

                    case 3:

                        sector1.ControlAutomatico();

                        Console.WriteLine("Control automático ejecutado...");
                        break;

                    case 4:

                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:

                        Console.WriteLine("Opción inválida");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();

            } while (opcion != 4);
        }
    }
}
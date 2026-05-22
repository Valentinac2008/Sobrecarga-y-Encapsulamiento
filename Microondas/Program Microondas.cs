using System;

namespace SimuladorMicroondas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese potencia (1 al 10): ");
            int potencia = int.Parse(Console.ReadLine());

            Microondas microondas =
                new Microondas(potencia);

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine(
                    "=== MICROONDAS DIGITAL ==="
                );

                Console.WriteLine(
                    $"Puerta: {(microondas.PuertaAbierta ? "ABIERTA" : "CERRADA")}"
                );

                Console.WriteLine(
                    $"Potencia: {microondas.Potencia}"
                );

                Console.WriteLine(
                    $"Tiempo: {microondas.PantallaTiempo}"
                );

                Console.WriteLine(
                    $"Funcionando: {(microondas.EnFuncionamiento ? "SI" : "NO")}"
                );

                Console.WriteLine();
                Console.WriteLine("1 - Abrir/Cerrar puerta");
                Console.WriteLine("2 - Agregar 30 segundos");
                Console.WriteLine("3 - Agregar tiempo personalizado");
                Console.WriteLine("4 - Iniciar");
                Console.WriteLine("5 - Detener");
                Console.WriteLine("0 - Salir");

                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(
                    Console.ReadLine()
                );

                switch (opcion)
                {
                    case 1:

                        microondas.AbrirCerrarPuerta();

                        break;

                    case 2:

                        microondas.AgregarTiempo();

                        break;

                    case 3:

                        Console.Write(
                            "Ingrese segundos: "
                        );

                        int segundos = int.Parse(
                            Console.ReadLine()
                        );

                        microondas.AgregarTiempo(
                            segundos
                        );

                        break;

                    case 4:

                        microondas.Iniciar();

                        break;

                    case 5:

                        microondas.Detener();

                        break;
                }

                Console.WriteLine();
                Console.WriteLine(
                    "Presione ENTER para continuar..."
                );

                Console.ReadLine();

            } while (opcion != 0);
        }
    }
}
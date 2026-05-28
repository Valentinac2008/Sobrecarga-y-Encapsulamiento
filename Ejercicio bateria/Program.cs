using System;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bateria telefono = new Bateria();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== SIMULADOR DE BATERIA =====");
                Console.WriteLine();

                Console.WriteLine(telefono.EstadoTexto);

                Console.WriteLine($"Salud de la batería: {telefono.SaludBateria}%");

                Console.WriteLine($"Modo ahorro: {(telefono.ModoAhorroEnergia ? "ACTIVO" : "INACTIVO")}");

                Console.WriteLine($"Cargador: {(telefono.ConectadoCargador ? "CONECTADO" : "DESCONECTADO")}");

                Console.WriteLine();
                Console.WriteLine("1 - Conectar / Desconectar cargador");
                Console.WriteLine("2 - Usar teléfono en reposo");
                Console.WriteLine("3 - Abrir aplicación pesada");
                Console.WriteLine("4 - Simular carga");
                Console.WriteLine("5 - Salir");

                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        telefono.AlternarCargador();

                        Console.WriteLine("Estado del cargador cambiado...");
                        break;

                    case 2:


                        telefono.ConsumirEnergia();

                        Console.WriteLine("Consumo base aplicado...");
                        break;

                    case 3:

                        Console.Write("¿Cuánta batería consume la app?: ");

                        int consumo = Convert.ToInt32(Console.ReadLine());


                        telefono.ConsumirEnergia(consumo);

                        Console.WriteLine("Aplicación utilizada...");
                        break;

                    case 4:

                        telefono.CicloDeCarga();

                        Console.WriteLine("Cargando batería...");
                        break;

                    case 5:

                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:

                        Console.WriteLine("Opción inválida...");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();

            } while (opcion != 5);
        }
    }
}
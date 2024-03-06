using System;

namespace Lavadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ContadorClientes = 0;
            string respuesta;

            do
            {
                Lavadora lavadora1 = new Lavadora();
                lavadora1.inicio();

                Console.WriteLine("\n¿Desea realizar otro ciclo?");
                Console.WriteLine("Presione Q para finalizar o cualquier tecla para continuar.");
                respuesta = Console.ReadLine();

                ContadorClientes++;

            } while (respuesta.ToUpper() != "Q");


            Console.WriteLine($"\nNúmero de clientes atendidos: {ContadorClientes}");
            Console.ReadKey();
        }
    }
}

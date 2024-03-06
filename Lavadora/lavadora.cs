using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lavadora
{
    internal class Lavadora
    {
        private int Kilos;
        private int TipoRopa;
        private int TiempoLavado;
        private const int CostoKilo = 4000;
        private Stopwatch cronometro;
        private string nombre;
        private DateTime FechaDeLavado = DateTime.Now;


        public Lavadora()
        {
            Kilos = 0;
            TipoRopa = 0;
            TiempoLavado = 7000;
            nombre = "";
            cronometro = new Stopwatch(); // Proporciona un conjunto de metodos y propiedades que puede usar para medir el tiempo trascurrido con precision
        }
        public void Menu()
        {
            Console.WriteLine("\n=== Bienvenido a Lavadora Mabe ===\n");

            Console.WriteLine("Ingrese su nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("\nIngrese los kilos de ropa que desea lavar:");
            while (!int.TryParse(Console.ReadLine(), out Kilos) || Kilos < 10 || Kilos > 30)
            {
                Console.WriteLine("La capacidad mínima de lavado es de 10 kg y la máxima es de 30 kg. Intente nuevamente:");
            }

            Console.WriteLine("\nSeleccione el Tipo de ropa\n" +
                "1.Ropa de colores\n" +
                "2.Algodon\n" +
                "3.Lycra\n" +
                "4.Sedas\n" +
                "5.Telas que puedan achicarse\n" +
                "6.prendas delicadas\n" +
                "7.Jeans\n" +
                "8.Camperas\n" +
                "9.Ropa poco delicada\n" +
                "10.Toallas\n" +
                "11.Cortinas de tela\n" +
                "12.Sabanas\n" +
                "13.Ropa muy sucia"
                );
            while (!int.TryParse(Console.ReadLine(), out TipoRopa) || TipoRopa <= 0 || TipoRopa > 13)
            {
                Console.WriteLine("Ingrese valores validos");
            }

            if (TipoRopa >= 1 && TipoRopa <= 5)
            {
                Console.WriteLine("\nRecomencacion de lavado para el tipo de ropa seleccionado!\n" +
                    "Agua fría (hasta 20º): Se recomienda para ropa de colores, algodón, lycra, sedas, prendas delicadas y telas que puedan achicarse.");
            }
            else if (TipoRopa >= 6 && TipoRopa <= 9)
            {
                Console.WriteLine("\nRecomencacion de lavado para el tipo de ropa seleccionado!\n" +
                    "Agua tibia (entre 30 a 50º): se recomienda para jeans, camperas, ropa muy sucia o poco delicada.");
            }
            else if (TipoRopa >= 10 && TipoRopa <= 12)
            {
                Console.WriteLine("\nRecomencacion de lavado para el tipo de ropa seleccionado!\n" +
                    "Agua caliente (entre 55 a 90º): se recomienda para toallas, sábanas o acolchados, telas blancas gruesas y cortinas de tela. ");
            }

            if (TipoRopa == 13)
            {
                Console.WriteLine("\nRecomencacion de lavado para el tipo de ropa seleccionado!\n" +
                    "Agua tibia (entre 30 a 50º): se recomienda para jeans, camperas, ropa muy sucia o poco delicada.\n");

                Console.WriteLine("\nFije el tiempo de lavado");
                while (!int.TryParse(Console.ReadLine(), out TiempoLavado) || TiempoLavado < 0)
                {
                    Console.WriteLine("Ingrese valores validos, el tiempo de lavado no puede ser menor a 0min");
                }

            }


        }
        public void inicio()
        {
            Menu();
            llenadoDeAgua();
            Lavado();
            Enjuague();
            Secado();
            CicloTerminado();
            CostoLavada();

        }
        private enum Sonidos
        {
            Llenando,
            Lavando,
            Enjuagando,
            Secando,
            CicloTerminado
        }


        private void ReproducirSonido(Sonidos sonido)
        {
            switch (sonido)
            {
                case Sonidos.Llenando:
                    Console.Beep(2000, 1000);
                    break;
                case Sonidos.Lavando:
                    Console.Beep(2000, 1000);
                    break;
                case Sonidos.Enjuagando:
                    Console.Beep(2000, 1000);
                    break;
                case Sonidos.Secando:
                    Console.Beep(2000, 1000);
                    break;
                case Sonidos.CicloTerminado:
                    Console.Beep(2000, 1000);
                    break;
                default:
                    break;
            }
        }



        private void llenadoDeAgua()
        {
            Console.WriteLine("\nLlenando...");
            ReproducirSonido(Sonidos.Llenando);
            Thread.Sleep(7000); //Suspende el subproceso actual durante el número de milisegundos especificado
        }

        private void Lavado()
        {
            cronometro.Start();
            Console.WriteLine("Lavando...");
            ReproducirSonido(Sonidos.Lavando);
            Thread.Sleep(TiempoLavado);
        }

        private void Enjuague()
        {
            Console.WriteLine("Enjuagando...");
            ReproducirSonido(Sonidos.Enjuagando);
            Thread.Sleep(7000);
        }

        private void Secado()
        {
            string respuesta;
            do
            {
                Console.WriteLine("\n¿Desea secar las prendas de una vez? S/N");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S" && respuesta != "N")
                {
                    Console.Write("Ingrese valores validos");
                }
                else if (respuesta == "S")
                {
                    Console.WriteLine("Secando...");
                    ReproducirSonido(Sonidos.Secando);
                    Thread.Sleep(7000);
                }
                else if (respuesta == "N")
                {
                    Console.WriteLine("Precione cualquier tecla para REANUDAR el ciclo de secado");
                    Console.ReadKey();
                    Console.WriteLine("Secando...");
                    ReproducirSonido(Sonidos.Secando);
                    Thread.Sleep(7000);
                }
            }
            while (respuesta != "S" && respuesta != "N");

        }

        private void CicloTerminado()
        {
            cronometro.Stop();
            TimeSpan tiempoTranscurrido = cronometro.Elapsed;
            Console.WriteLine("Ciclo terminado!");
            Console.WriteLine($"{nombre} El tiempo de lavado fue: {tiempoTranscurrido.TotalSeconds} segundos. Fecha de registro: {FechaDeLavado}");
            ReproducirSonido(Sonidos.CicloTerminado);
        }


        private void CostoLavada()
        {
            int SubTotal;
            int IVA;
            int Total;
            int Incremento;
            int GananciaJefe;

            if (TipoRopa == 1 || TipoRopa == 2)
            {
                Incremento = (CostoKilo * 5) / 100;
                SubTotal = (CostoKilo + Incremento) * Kilos;
                IVA = (SubTotal * 19) / 100;
                Total = SubTotal + IVA;
                GananciaJefe = (SubTotal * 30) / 100;
                Console.WriteLine($"\nCosto de lavado (IVA incluido) por {Kilos} kg de ropa: ${Total}");
                Console.WriteLine($"La ganancia del jefe es: ${GananciaJefe}");
                double KwHConsumida = (TiempoLavado + 7000 + 7000 + 7000) / 3600.0; // Convertir de segundos a horas
                double CostoKwH = 516.72;
                double CostoConsumo = KwHConsumida * CostoKwH;
                CostoConsumo = Math.Round(CostoConsumo, 2);
                Console.WriteLine($"El costo total de consumo de energía es de ${CostoConsumo}");


                //Console.WriteLine($"{incremento} - {SubTotal} - {IVA} - {Total}");
            }
            else
            {
                SubTotal = CostoKilo * Kilos;
                IVA = (SubTotal * 19) / 100;
                Total = SubTotal + IVA;
                GananciaJefe = (SubTotal * 30) / 100;
                Console.WriteLine($"\nCosto de lavado (IVA incluido) por {Kilos} kg de ropa: ${Total}");
                Console.WriteLine($"La ganancia del jefe es: ${GananciaJefe}");
                double KwHConsumida = (TiempoLavado + 7000 + 7000 + 7000) / 3600.0; // Convertir de segundos a horas
                double CostoKwH = 516.72;
                double CostoConsumo = KwHConsumida * CostoKwH;
                CostoConsumo = Math.Round(CostoConsumo, 2);
                Console.WriteLine($"El costo total de consumo de energía es de ${CostoConsumo}");

            }
        }
    }
}

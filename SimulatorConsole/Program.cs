using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace SimulatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightPlanList lista = new FlightPlanList();
            try
            {
                int count = 0;
                while (count < 2)
                {
                    Console.WriteLine("Escribe el identificador");
                    //   string nombre = Console.ReadLine();
                    string identificador = Console.ReadLine();

                    Console.WriteLine("Escribe la velocidad");
                    double velocidad = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                    string linea = Console.ReadLine();
                    string[] trozos = linea.Split(' ');
                    double ix = Convert.ToDouble(trozos[0]);
                    double iy = Convert.ToDouble(trozos[1]);

                    Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                    linea = Console.ReadLine();
                    trozos = linea.Split(' ');
                    double fx = Convert.ToDouble(trozos[0]);
                    double fy = Convert.ToDouble(trozos[1]);

                    FlightPlan plan = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);
                    lista.AddFlightPlan(plan);

                    count++;

                }

                int ciclos = 10;
                int intervaloTiempo = 10;
                double distanciaSeguridad = 10;
                
                int i = 0;
                while(i < ciclos)
                {
                    lista.Mover(intervaloTiempo);
                    if (lista.GetFlightPlan(0).Conflicto(lista.GetFlightPlan(1), distanciaSeguridad))
                        Console.WriteLine("CONFLICTO!!");
                    i++;
                }

                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("There is a format error, please try again");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The number of values is not correct, introduce 2 nubers separated by comas");
            }
            Console.ReadKey();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleAppEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays.Ejercicio1();

            Console.ReadKey();
        }
    }

    public static class Arrays
    {
        public static void Ejercicio1()
        {
            string[] letras = new string[] { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N", "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E", "T" };

            Console.Write("Número DNI: ");
            string dni = Console.ReadLine();
            int numero;

            if (dni.Length <= 8)
            {
                if (dni.Length < 8) dni = dni.PadLeft(8, '0');

                switch (dni[0].ToString().ToUpper())
                {
                    case "X":
                        dni = dni.Substring(1, 7);
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIF es X" + numero.ToString() + letras[numero % 23]
                            : "Error al procesar el NIE");
                        break;
                    case "Y":
                        dni = dni.Substring(1, 7);
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIF es Y" + numero.ToString() + letras[(10000000 + numero) % 23]
                            : "Error al procesar el NIE");
                        break;
                    case "Z":
                        dni = dni.Substring(1, 7);                        
                        Console.WriteLine(int.TryParse(dni, out numero)
                            ? "El NIF es Z" + numero.ToString() + letras[(20000000 +numero) % 23]
                            : "Error al procesar el NIE");
                        break;
                    default:
                        Console.WriteLine(int.TryParse(dni, out numero) 
                            ? "El NIF es " + numero.ToString() + letras[numero % 23]
                            : "Error al procesar el NIF");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Error: El DNI tiene más de 8 caracteres.");
            }
        }
    }

    public static class Repeticion
    {
        //Pinta los número paras del 50 al 150
        public static void Ejercicio1()
        {
            for (var i = 50; i < 151; i+=2)
            {
                Console.WriteLine("{0}", i);
            }
        }

        //Pinta los número impares del 1000 al 500
        public static void Ejercicio2()
        {
            for (var i = 999; i > 499; i-=2)
            {
                Console.WriteLine("{0}", i);
            }
        }

        //Pinta números del 0 al 100 de 5 en 5
        public static void Ejercicio3()
        {
            for (var i = 0; i <= 100; i+=5)
            {
                Console.WriteLine("{0}", i);
            }
        }

        //Pinta números del 100 al 0 de 10 en 10
        public static void Ejercicio4()
        {
            for (var i = 100; i >= 0; i -= 10)
            {
                Console.WriteLine("{0}", i);
            }
        }
    }
}

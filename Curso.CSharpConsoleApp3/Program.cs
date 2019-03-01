using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos un Array con Split
            string nombre = "Borja Cabeza Rozas";
            var array5 = nombre.Split(' ');

            //Recorremos un Array
            for (int i = 0; i < array5.Length; i++)
            {
                Console.WriteLine("{0}# {1}", i, array5[i]);
            }

            foreach (string valor in array5)
            {
                Console.WriteLine("Valor: {0}", valor);
            }


            Console.ReadKey();





            //Creamos un Array de enteros con 10 posiciones de la 0 a la 9.
            int[] array = new int[10];
            int[] array1 = new int[] { 1, 85, 74, 1200, 0, -32, 14 };
            int[] array2 = { 1, 85, 74, 1200, 0, -32, 14 };

            //Asignamos el valor 32 que se almacena en la posición 4
            array[4] = 32;

            //Leermos el contenido de la posición 4
            Console.WriteLine(array[4]);


            //Array Multidimensionales
            int[,] array3 = new int[10, 5];
            array3[0, 4] = 32;

            //Array Jagged
            int[][] array4 = new int[10][];
            array4[0] = new int[1000];
            array4[1] = new int[10];
            array4[2] = new int[43];
            array4[3] = new int[] { 85, 20, 23, 15, 22, 2222, 10, -32, 45, 202, };

            array4[0][995] = 14000;
            array4[1][4] = 3100;

            Console.ReadKey();
        }
    }
}

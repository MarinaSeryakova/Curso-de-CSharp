using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();

            //array.Add("ana");
            //array.Add("Javier");
            //array.Add("Borja");
            //array.Add("María");
            //array.Add("josé");
            //array.Add("José Antonio");
            //array.Add("LUCIA");

            //array.Add(100);
            //array.Add(30);
            //array.Add(185);
            //array.Add(2010);
            //array.Add(10);
            //array.Add(7850);

            array.Add(new Alumno() { Nombre = "Ana", Edad = 34 });
            array.Add(new Alumno() { Nombre = "Lucia", Edad = 28 });
            array.Add(new Alumno() { Nombre = "Lucia", Edad = 32 });
            array.Add(new Alumno() { Nombre = "José Antonio", Edad = 41 });
            array.Add(new Alumno() { Nombre = "José", Edad = 23 });
            array.Add(new Alumno() { Nombre = "Antonio", Edad = 27 });

            array.Sort(new OrdenarAlumno());

            foreach (var item in array)
            {
                Console.WriteLine("{0} - {1} años", ((Alumno)item).Nombre , ((Alumno)item).Edad);
            }
            Console.ReadKey();

            //Añadir elementos nuevos
            array.Add("hola");
            array.Add(34);
            array.Add(new Alumno() { Nombre = "Borja", Edad = 34 });

            //Añadir una colección de elementos, una posición para cada uno de ellos.
            array.AddRange(new int[] { 34, 124, 85 ,32 });

            //Limpiar toda la colección
            array.Clear();

            //Elimina el elemento especificado
            array.Remove("hola");

            //Elimina el elemento de la posición 1
            array.RemoveAt(1);



            Hashtable dictonary = new Hashtable();
            dictonary.Add("bor", "Borja");
            dictonary.Add("ana", "Ana");
            dictonary.Add("jse", "José");
            dictonary.Add("luc", "Lucia");

            dictonary["luc"] = "Anrtonia";

            foreach (var i in dictonary.Keys)
            {
                Console.WriteLine("{0}", dictonary[i]);
            }



            List<string> list = new List<string>();

            Dictionary<int, string> dictonary2 = new Dictionary<int, string>();

            Queue<string> queue = new Queue<string>();
            //Añadir nuevo elemento
            queue.Enqueue("valor");

            //Eliminar elemento de la posición 0
            string eliminado = queue.Dequeue();


            Stack<string> stack = new Stack<string>();
            //Añadir nuevo elemento
            stack.Push("valor");

            //Eliminar elemento de la posición 0
            string eliminado2 = stack.Pop();

            //Retorno de elemento posición 0 sin eliminar
            string elemento = stack.Peek();



            SortedList<int, string> sortList = new SortedList<int, string>();

        }
    }

    public class Alumno
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

    public class OrdenarNombre : IComparer
    {
        public int Compare(object x, object y)
        {
            Alumno alumnoX = (Alumno)x;
            Alumno alumnoY = (Alumno)y;

            return (new CaseInsensitiveComparer()).Compare(alumnoX.Nombre, alumnoY.Nombre);
        }
    }

    public class OrdenarEdad : IComparer
    {
        public int Compare(object x, object y)
        {
            Alumno alumnoX = (Alumno)x;
            Alumno alumnoY = (Alumno)y;

            return alumnoX.Edad.CompareTo(alumnoY.Edad);
        }
    }

    public class OrdenarAlumno : IComparer
    {
        public int Compare(object x, object y)
        {
            Alumno alumnoX = (Alumno)x;
            Alumno alumnoY = (Alumno)y;

            if (alumnoX.Nombre.CompareTo(alumnoY.Nombre) == 0) return alumnoX.Edad.CompareTo(alumnoY.Edad);
            else return alumnoX.Nombre.CompareTo(alumnoY.Nombre);

        }
    }
}

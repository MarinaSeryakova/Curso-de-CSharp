using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsolaApp1
{
    public delegate void Notificacion(string mensaje);
    public enum TipoAlumno : int { Prescolar = 100, Primarios, FP = 200, Universidad };
    class Program
    {
        static void Main(string[] args)
        {
            Tools.Operadores();


            Notificacion notificacion = MetodoPrueba;
            notificacion("Prueba de Delagados");

            Notificacion notificacion2 = delegate (string m) {
                Console.WriteLine("Notificación: {0}", m);
            };
            notificacion2("Prueba de Delagados");

            Notificacion notificacion3 = mensaje => {
                Console.WriteLine("Info: {0}", mensaje);
            };
            notificacion3("Prueba de Delagados");

            Console.ReadKey();

            //=========================================================================

            Alumno alumno = new Alumno() {
                Nombre = "Borja",
                Apellidos = "Cabeza",
                Edad = 45,
                Tipo = TipoAlumno.Primarios
               
            };

            Alumno alumno2 = new Alumno();
            alumno2.Nombre = "Borja";
            alumno2.Apellidos = "Cabeza";
            alumno2.Edad = 45;

            var alumno3 = new Alumno()
            {
                Nombre = "Borja",
                Apellidos = "Cabeza",
                Edad = 45
            };

            object alumno4 = new Alumno()
            {
                Nombre = "Borja",
                Apellidos = "Cabeza",
                Edad = 45
            };

            dynamic alumno5 = new Alumno()
            {
                Nombre = "Borja",
                Apellidos = "Cabeza",
                Edad = 45
            };

            Console.WriteLine("Nombre: {0}", ((Alumno)alumno5).Nombre);
            Console.WriteLine("Apellidos: {0}", alumno5.Apellidos);
            Console.WriteLine("Edad: {0}", alumno5.Edad);
            Console.WriteLine("");
            Console.WriteLine("Nombre: {0}", ((Alumno)alumno4).Nombre);
            Console.WriteLine("Apellidos: {0}", ((Alumno)alumno4).Apellidos);
            Console.WriteLine("Edad: {0}", ((Alumno)alumno4).Edad);
            Console.WriteLine("");
            Console.WriteLine("Nombre: {0}", alumno.Nombre);
            Console.WriteLine("Apellidos: {0}", alumno.Apellidos);
            Console.WriteLine("Edad: {0}", alumno.Edad);
            Console.WriteLine("Tipo: {0}", alumno.Tipo);
            Console.WriteLine("Tipo: {0}", (int)alumno.Tipo);

            Console.ReadKey();
        }

        public static void MetodoPrueba(string m)
        {
            Console.Clear();
            Console.WriteLine("Mensaje: {0}", m);
        }
    }
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public TipoAlumno Tipo { get; set; }

        public void Imprimir()
        {
        }

    }
    public static class Tools
    {
        public static void Operadores()
        {
            int a = 10;
            int b = 30;

            Console.Clear();
            Console.WriteLine("Resultado: {0}", a);
            Console.WriteLine("Resultado: {0}", ++a);
            Console.WriteLine("Resultado: {0}", a);
            Console.ReadKey();
        }
    }
}

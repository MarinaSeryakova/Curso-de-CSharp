using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.CSharp.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno = new Alumno();
            alumno.Edad = 40;
            alumno.NombreCompleto = "Francisco de Borja Cabeza Rozas";

            Console.WriteLine("Nombre: {0}", alumno.Nombre);
            Console.WriteLine("Apellidos: {0}", alumno.Apellidos);
            Console.WriteLine("Edad: {0}", alumno.Edad);
            Console.ReadKey();

            int num1 = 10;
            int num2 = 10;

            Console.WriteLine("Num1: {0} - Num2: {1}", num1, num2);
            ProcesaNumero(num1, ref num2);
            Console.WriteLine("Num1: {0} - Num2: {1}", num1, num2);
            Console.ReadKey();


            byte retorno = 0;
            Console.WriteLine("Resultado: {0} - Valor: {1}", Conversor(500, out retorno), retorno);
            Console.ReadKey();

            string valor = "1459";
            int numero = 0;
            bool resultado;

            resultado = Int32.TryParse(valor, out numero);
            Console.WriteLine("Resultado: {0} - Valor: {1}", resultado, numero);
            Console.ReadKey();

            int a = 0;
            long b = 325;

            //Método Convert
            a = Convert.ToInt32(b);
            Console.WriteLine("Valor de a: {0}", a);

            //Conversión Explicita
            a = (int)b;
            Console.WriteLine("Valor de a: {0}", a);

            //Conversión Implicita
            b = a;
            Console.WriteLine("Valor de b: {0}", b);


            Console.ReadKey();
        }

        static void ProcesaNumero(int a, ref int b)
        {
            a = 30;
            b = 30;
        }

        static bool Conversor(decimal n, out byte r)
        {
            try
            {
                r = Convert.ToByte(n);
                return true;
            }
            catch (Exception)
            {
                r = 0;
                return false;
            }
        }

        static bool Conversor(int n, out byte r)
        {
            return byte.TryParse(n.ToString(), out r);
        }

        static bool Conversor(double n, out byte r)
        {
            return byte.TryParse(n.ToString(), out r);
        }
    }

    public class Alumno
    {
        private int edad;
        private string apellidos;
        private string nombre;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (value.Length < 3) nombre = "";
                else nombre = value;
            }
        }
        public string Apellidos
        {
            get => apellidos;
            set
            {
                if (value.Length < 3) apellidos = "";
                else apellidos = value;
            }
        }
        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                if (value < 0 || value > 120) edad = 0;
                else edad = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return nombre + " " + apellidos;
            }

            set
            {
                var datos = value.Split(' ');

                if (datos.Length >= 3)
                {
                    apellidos = datos[datos.Length - 2] + " " + datos[datos.Length - 1];

                    nombre = "";
                    for (var i = 0; i < datos.Length - 2; i++)
                    {
                        nombre += nombre.Length == 0 ? datos[i] : " " + datos[i];
                    }
                }
            }
        }

        private void Inicializa(string v1, string v2, int p = -1)
        {
            nombre = v1;
            apellidos = v2;
            edad = p;
        }

        public Alumno()
        {
            Inicializa("", "");
        }
        public Alumno(string Nombre, string Apellidos)
        {
            Inicializa(Nombre, Apellidos);
        }
        public Alumno(string Nombre, string Apellidos, int Edad)
        {
            Inicializa(Nombre, Apellidos, Edad);
        }
        
        ~Alumno()
        {
            nombre = null;
            apellidos = null;
            edad = 0;
        }
    }

}

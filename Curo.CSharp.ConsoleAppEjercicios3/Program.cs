using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curo.CSharp.ConsoleAppEjercicios3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tareas tareas = new Tareas();

            tareas.FinCalcular += (sender, e) => {
                Console.WriteLine("Suma 1: {0}", e);
            };

            tareas.FinCalcular2 += (sender, e) => {
                Console.WriteLine("Suma 2: {0}", e);
            };

            tareas.FinCalcular3 += (sender, e) => {
                Console.WriteLine("Suma 3: {0}", e);
            };

            tareas.Iniciar();

            
            Console.ReadKey();
        }
    }

    public class Tareas
    {
        public event EventHandler<decimal> FinCalcular;
        public event EventHandler<decimal> FinCalcular2;
        public event EventHandler<decimal> FinCalcular3;

        public async void Iniciar()
        {
            var datos = await PedidosTotal();
            foreach (var k in datos.Keys)
            {
                Console.WriteLine("{0}# -> {1}", k, datos[k].ToString("N2").PadLeft(10));
            }
            Console.ReadKey();

            Parallel.Invoke(
                () => { CalcularAsync(); },
                () => { Calcular2Async(); },
                () => { Calcular3Async(); });
        }

        public async Task<decimal> CalcularAsync()
        {
            return await Task.Run(() => {
                var lista = Enumerable.Range(0, 200000);
                decimal suma = 0;

                foreach(var item in lista)
                {
                    suma += item;
                }

                FinCalcular?.Invoke(this, suma);

                return suma;
            });            
        }

        public async Task<decimal> Calcular2Async()
        {
            Task<decimal> tarea1 = Task.Run(() => {
                var lista = Enumerable.Range(1000, 3000);
                decimal suma = 0;

                foreach (var item in lista)
                {
                    suma += item;
                }

                FinCalcular2?.Invoke(this, suma);

                return suma;
            });

            return await tarea1;
        }

        public async Task<decimal> Calcular3Async()
        {
            return await Task.Run(() => {
                var lista = Enumerable.Range(0, 200000);
                decimal suma = 0;

                Parallel.ForEach(lista, (num) => { suma += num; });                

                FinCalcular3?.Invoke(this, suma);

                return suma;
            });
        }

        public async Task<Dictionary<int, decimal>> PedidosTotal()
        {
            //Diccionario con IdPedido y Coste Total del Pedido
            
            //Dictionary<int, decimal> datos2 = db.Order_Details
            //    .GroupBy(r => r.OrderID)
            //    .Select(r => new KeyValuePair<int, decimal>(r.Key, r.Sum(s => s.Quantity * s.UnitPrice)))
            //    .ToDictionary(k => k.Key, v => v.Value);

            //Dictionary<int, decimal> datos2 = db.Orders
            //.Select(r => new
            //{
            //    id = r.OrderID,
            //    total = r.Order_Details
            //        .Where(s => s.OrderID == r.OrderID).Sum(h => h.Quantity * h.UnitPrice)
            //})
            //.ToDictionary(r => r.id, r => r.total);

            return await Task.Run(() => {
                Models.ModelNorthwind db = new Models.ModelNorthwind();
                Dictionary<int, decimal> datos = new Dictionary<int, decimal>();

                datos = db.Order_Details.AsParallel()
                    .GroupBy(r => r.OrderID)
                    .Select(r => new { clave = r.Key, total = r.AsParallel().Sum(s => s.Quantity * s.UnitPrice) })
                    .ToDictionary(r => r.clave, r => r.total);

                return datos;            
            });
        }
    }
}

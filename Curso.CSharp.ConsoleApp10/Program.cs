using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.CSharp.ConsoleApp10.Models;

namespace Curso.CSharp.ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            ModelNorthwind db = new ModelNorthwind();

            //Clientes que no han comprado nada
            var clientesOut = db.Customers
                .Where(r => !r.Orders.Any())
                .Select(r => r.CompanyName)
                .ToList();

            var clientesOut2 = db.Customers
                .Where(r => r.Orders.Count() == 0)
                .Select(r => r.CompanyName)
                .ToList();

            foreach (var cliente in clientesOut)
            {
                Console.WriteLine("{0}", cliente);
            }
            Console.ReadKey();

            //Nombre y Apellidos de empleados que llevan trabajando más timepo que el empleado
            //más antiguo de Londres
            var empleados4 = db.Employees
                .Where(r => r.City != "London" &&
                    r.HireDate < db.Employees.Where(s => s.City == "London").Min(s => s.HireDate))
                .Select(r => new { r.LastName, r.FirstName })
                .ToList();

            foreach (var empleado in empleados4)
            {
                Console.WriteLine("{0} {1}", empleado.FirstName, empleado.LastName);
            }
            Console.ReadKey();


            //Fecha de incorporación del empleado más antiguo de Londres
            var fecha2 = db.Employees
                .Where(r => r.City == "London")
                .Min(r => r.HireDate);

            var fecha3 = db.Employees
                .Where(r => r.City == "London")
                .Select(r => r.HireDate)
                .Min();

            var fecha4 = db.Employees
                .Where(r => r.City == "London")
                .OrderBy(r => r.HireDate)
                .FirstOrDefault().HireDate;

            //Empleado con 50 años o más
            DateTime fecha = DateTime.Now.AddYears(-50);

            var empleadosMayores = db.Employees
                .Where(r => r.BirthDate < fecha).ToList();

            foreach (var empleado in empleadosMayores)
            {
                Console.WriteLine("{0} {1}", empleado.FirstName, empleado.LastName);
            }
            Console.ReadKey();


            //Empleados que ha tramitado pedidos con destino España
            var empleados = db.Employees
                .Join(db.Orders,
                    e => e.EmployeeID,
                    o => o.EmployeeID,
                    (e, o) => new { e.FirstName, e.LastName, o.ShipCountry })
                .Where(r => r.ShipCountry == "Spain")
                .Distinct()
                .ToList();

            foreach (var empleado in empleados)
            {
                Console.WriteLine("{0} {1}", empleado.FirstName, empleado.LastName);
            }
            Console.ReadKey();










            //Número de clientes por pais con SubSelect
            var paises = db.Customers
                .Select(r => r.Country)
                .Distinct()
                .ToList();

            foreach (var pais in paises)
            {
                Console.WriteLine("País: {0} - {1} clientes", 
                    pais, 
                    db.Customers.Where(r => r.Country == pais).Count());
            }
            Console.ReadKey();
            
            //Número de clientes por pais con GroupBy
            var clientes2 = db.Customers
                .GroupBy(r => r.Country)
                .Select(r => new { pais = r.Key, clientes = r.Count() })
                .ToList();

            foreach (var cliente in clientes2)
            {
                Console.WriteLine("País: {0} - {1} clientes", cliente.pais, cliente.clientes);
            }
            Console.ReadKey();

            //Listado de Clientes
            var clientes = db.Customers
                .Where(r => r.Country == "Mexico")
                .ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine("{0}# - {1} - {2} ({3})",
                    cliente.CustomerID, cliente.CompanyName, cliente.City, cliente.Country);
            }
            Console.WriteLine("{0} registros recuperados", clientes.Count());

            Console.ReadKey();
        }
    }
}

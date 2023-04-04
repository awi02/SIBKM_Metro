using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Models;
namespace Connection.Views
{
    internal class Vreg
    {
        public void GetAll(List<Region> regions)
        {
            foreach (var region in regions)
            {
                Console.WriteLine("=================");
                Console.WriteLine("Id: " + region.Id);
                Console.WriteLine("Name: " + region.Name);
            }
        }
        public void GetById(Region region)
        {
            Console.WriteLine("=================");
            Console.WriteLine("Id: " + region.Id);
            Console.WriteLine("Name: " + region.Name);
        }
        public void Success(string message)
        {
            Console.WriteLine($"Data has been {message}");
        }

        public void Failure(string message)
        {
            Console.WriteLine($"Data has not been {message}");
        }

        public void DataNotFound()
        {
            Console.WriteLine("Data Not Found!");
        }
    }
}

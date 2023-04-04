using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Views
{
    internal class Vcont
    {
        public void GetAll(List<Country> countrys)
        {
            foreach (var country in countrys)
            {
                Console.WriteLine("=================");
                Console.WriteLine("Id: " + country.Id);
                Console.WriteLine("Name: " + country.Name);
                Console.WriteLine("Region: " + country.Region);
            }
        }
        public void GetById(Country country)
        {
            Console.WriteLine("=================");
            Console.WriteLine("Id: " + country.Id);
            Console.WriteLine("Name: " + country.Name);
            Console.WriteLine("Region: " + country.Region);
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

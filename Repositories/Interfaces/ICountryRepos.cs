using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Repositories.Interfaces
{
    internal interface ICountryRepos
    {
        List<Country> GetAll();
        Country GetById(string id);
        int Insert(Country country);
        int Update(Country country);
        int Delete(string id);
    }
}

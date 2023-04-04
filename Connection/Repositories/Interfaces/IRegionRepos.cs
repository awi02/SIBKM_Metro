using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection.Models;

namespace Connection.Repositories.Interfaces
{
    internal interface IRegionRepos
    {
        List<Region> GetAll();
        Region GetById(int id);
        int Insert (Region region);
        int Update (Region region);
        int Delete(int id);
    }
}

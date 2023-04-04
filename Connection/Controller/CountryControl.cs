using Connection.Models;
using Connection.Repositories.Interfaces;
using Connection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Controller
{
    internal class CountryControl
    {
        private readonly ICountryRepos _countryRepos;
        private readonly Vcont _vcont;
        public CountryControl(ICountryRepos countryRepos, Vcont vcont)
        {
            _countryRepos = countryRepos;
            _vcont = vcont;
        }
        public void GetAll()
        {
            var countrys=_countryRepos.GetAll();
            if(countrys == null)
            {
                _vcont.DataNotFound();
            }
            _vcont.GetAll(countrys);
        }
        public void GetById(string id)
        {
            var country = _countryRepos.GetById(id);
            if (country == null)
            {
                _vcont.DataNotFound();
            }
            _vcont.GetById(country);
        }
        public void Insert(Country country)
        {
            var result = _countryRepos.Insert(country);
            if (result > 0)
            {
                _vcont.Success("inserted");
            }
            else
            {
                _vcont.Failure("insert");
            }
        }
        public void Update(Country country)
        {
            var result = _countryRepos.Update(country);
            if (result > 0)
            {
                _vcont.Success("Updated");
            }
            else
            {
                _vcont.Failure("Update");
            }
        }
        public void Delete(string id)
        {
            var result = _countryRepos.Delete(id);
            if (result > 0)
            {
                _vcont.Success("Deleted");
            }
            else
            {
                _vcont.Failure("Delete");
            }
        }
    }
}

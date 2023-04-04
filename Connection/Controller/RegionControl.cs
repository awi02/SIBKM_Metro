using Connection.Repositories.Interfaces;
using Connection.Views;
using Connection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Controller
{
    internal class RegionControl
    {
        private readonly IRegionRepos _regionRepos;
        private readonly Vreg _vreg;
        public RegionControl(IRegionRepos regionRepos, Vreg vreg)
        {
            _regionRepos = regionRepos;
            _vreg = vreg;
        }
        public void GetAll()
        {
            var regions=_regionRepos.GetAll();
            if(regions == null)
            {
                _vreg.DataNotFound();
            }
            _vreg.GetAll(regions);
        }
        // GET BY ID
        public void GetById(int id)
        {
            var region = _regionRepos.GetById(id);
            if (region == null)
            {
                _vreg.DataNotFound();
            }
            _vreg.GetById(region);
        }

        // INSERT
        public void Insert(Region region)
        {
            var result = _regionRepos.Insert(region);
            if (result > 0)
            {
                _vreg.Success("inserted");
            }
            else
            {
                _vreg.Failure("insert");
            }
        }

        // UPDATE
        public void Update(Region region)
        {
            var result = _regionRepos.Update(region);
            if (result > 0)
            {
                _vreg.Success("Updated");
            }
            else
            {
                _vreg.Failure("Update");
            }
        }


        // DELETE
        public void Delete(int id)
        {
            var result = _regionRepos.Delete(id);
            if (result > 0)
            {
                _vreg.Success("Deleted");
            }
            else
            {
                _vreg.Failure("Delete");
            }
        }

        }
}

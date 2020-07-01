using Project.DAL.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Project.Common.Functionalities
{
   public class SearchBy
    {
        public Expression<Func<VehicleMake, bool>> MakeSearchBy(string searchBy)
        {
            return  p=>p.Name.Contains(searchBy)||p.Abrv.Contains(searchBy);
        }

        public Expression<Func<VehicleModel, bool>> ModelSearchBy(string searchBy)
        {
            return p => p.VehicleMake.Name.Contains(searchBy);
        }

    }
}

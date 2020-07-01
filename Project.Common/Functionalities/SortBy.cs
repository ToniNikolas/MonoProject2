using Project.DAL.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common.Functionalities
{
    public class SortBy
    {

        public Func<IQueryable<VehicleMake>, IOrderedQueryable<VehicleMake>> MakeOrderBy(string orderBy)
        {
            Func<IQueryable<VehicleMake>, IOrderedQueryable<VehicleMake>> query;
            switch (orderBy)
            {
                case Strings.AbrvAsc:
                    query = p => p.OrderBy(r => r.Abrv);
                    break;

                case Strings.AbrvDesc:
                    query = p => p.OrderByDescending(r => r.Abrv);
                    break;

                case Strings.NameAsc:
                    query = p => p.OrderBy(r => r.Name);
                    break;

                case Strings.NameDesc:
                    query = p => p.OrderByDescending(r => r.Name);
                    break;

                default:
                    query = p => p.OrderBy(r => r.Name);
                    break;

            }

            return query;


        }
        public Func<IQueryable<VehicleModel>, IOrderedQueryable<VehicleModel>> ModelOrderBy(string orderBy)
        {
            Func<IQueryable<VehicleModel>, IOrderedQueryable<VehicleModel>> query;
            switch (orderBy)
            {
                case Strings.AbrvAsc:
                    query = p => p.OrderBy(r => r.Abrv);
                    break;

                case Strings.AbrvDesc:
                    query = p => p.OrderByDescending(r => r.Abrv);
                    break;

                case Strings.NameAsc:
                    query = p => p.OrderBy(r => r.VehicleMake.Name);
                    break;

                case Strings.NameDesc:
                    query = p => p.OrderByDescending(r => r.VehicleMake.Name);
                    break;

                case Strings.ModelAsc:
                    query = p => p.OrderBy(r => r.ModelName);
                    break;

                case Strings.ModelDesc:
                    query = p => p.OrderByDescending(r => r.ModelName);
                    break;

                default:
                    query = p => p.OrderBy(r => r.VehicleMake.Name);
                    break;

            }

            return query;

        }

    }
}

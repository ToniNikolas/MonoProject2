using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.DomainModels
{
   public class VehicleMakeDomain : IVehicleMakeDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModelDomain> VehicleModels { get; set; }
    }
}

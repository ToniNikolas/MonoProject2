using Project.Model.Common.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.DomainModels
{
   public class VehicleModelDomain : IVehicleModelDomain
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string ModelName { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMakeDomain VehicleMakeDomain { get; set; }
    }
}

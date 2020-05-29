using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Common.DomainInterfaces
{
    public interface IVehicleModelDomain
    {
         Guid Id { get; set; }
         Guid MakeId { get; set; }
         string ModelName { get; set; }
         string Abrv { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Common.DomainInterfaces
{
   public interface IVehicleMakeDomain
    {
         Guid Id { get; set; }
         string Name { get; set; }
         string Abrv { get; set; }
        
    }
}

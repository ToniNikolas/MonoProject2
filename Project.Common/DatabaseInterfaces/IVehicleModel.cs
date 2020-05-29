using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Common.DatabaseInterfaces
{
   public interface IVehicleModel
    {
        Guid Id { get; set; }
        Guid MakeId { get; set; }
        string ModelName { get; set; }
        string Abrv { get; set; }
    }
}

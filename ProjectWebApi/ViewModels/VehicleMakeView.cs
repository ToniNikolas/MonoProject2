using Project.DAL.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.ViewModels
{
    public class VehicleMakeView
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModelView> VehicleModelsView { get; set; }
    }
}

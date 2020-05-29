using Project.DAL.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.ViewModels
{
    public class VehicleModelView
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string Abrv { get; set; }
        public virtual VehicleMakeView VehicleMakeView { get; set; }
    }
}

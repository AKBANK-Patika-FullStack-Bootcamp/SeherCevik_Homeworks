using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RestaurantLibrarys.Entities.EntitiesModels
{
    public class Restaurant
    {
        
        public int Id { get; set; }
        public string? name { get; set; }
        [StringLength(50)]
        public string? city { get; set; }
        public ICollection<Employee> Employee { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrarys.Entities.EntitiesModels
{
    public class Employee
    {
        public int?  Id { get; set; }
        public string? name { get; set; }
        public string? LastName { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant restaurant { get; set; }
    }
}

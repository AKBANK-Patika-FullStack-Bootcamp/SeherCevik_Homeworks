using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrarys.Entities.EntitiesModels
{
    public class Result
    {
        public int Status { get; set; }
        public string? message { get; set; }
        public List<Restaurant>? RestaurantList { get; set; }
        public List<Employee>? EmployeeList { get; set; }
    }
}

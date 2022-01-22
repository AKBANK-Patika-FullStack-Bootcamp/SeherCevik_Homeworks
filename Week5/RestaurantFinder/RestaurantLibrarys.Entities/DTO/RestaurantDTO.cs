using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrarys.Entities.DTO
{
    //https://mehmetserkanekinci.medium.com/automapper-ve-dto-nedir-ve-nas%C4%B1l-kullan%C4%B1l%C4%B1r-c6c0d6621168

    public class RestaurantDTO
    {
        public string? name { get; set; }
        public string? city { get; set; }
    }
}

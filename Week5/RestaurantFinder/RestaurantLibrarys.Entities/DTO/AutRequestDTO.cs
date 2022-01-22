using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrarys.Entities.DTO
{
    //kullanıcının token almak için istek atarken göndermesi gereken veriler için oluşturduğumuz sınıftır.
    public class AutRequestDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}

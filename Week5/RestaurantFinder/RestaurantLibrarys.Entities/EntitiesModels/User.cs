using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantLibrarys.Entities.EntitiesModels
{
    public class User
    {
        //user bilgilerimizi veritabanında tutmak için oluşturduğumuz entiti sınıfımız.
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? UserName { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

    }
}

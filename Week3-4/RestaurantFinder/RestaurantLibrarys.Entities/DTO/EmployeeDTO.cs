using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrarys.Entities.DTO
{
    //neden DTO nedir; data transfer object data transferi için kullanılan sadece transfer data aktarımı yapmak için oluşturduğumuz sınıflardır. Entitilerimizn karşılığu normal programlamada direkt olarak veritabanında oluşacak tablolarımızın karışılığıdır.Tablolar= entitiy sınıfları . veritabanımızda entitimizi code first yapmık ıd otomarik artan olsun ama entiti de ıd alanı var controller de entiti class ının aynısını parametre olarak alırsak burada normalde bizim atamadığımız ıd değeri de ullanıcıdan beklenecektir. veyahut kullanıcının atmayacağı bizim default olarak tanımlayacağımız alanlar olabiliri.bu alanları içermeyen ıd veya kullanıcıdan almıcamız verileri içermeyen diğer kısımları entiti ile birebir aynı olan sınıflara DTO denir. Bu sadece kullanıcıdan programımıza veri alırken sadece ijhtiyacıomız olan verileri almak üzere entitimizden  ihtiyaçımız olmayan kısımları çıkararak oluşturduğumuz sınıflardır.
    public class EmployeeDTO
    {
        
        public string? name { get; set; }
        public string? LastName { get; set; }
        public int RestaurantId { get; set; }
        
    }
}

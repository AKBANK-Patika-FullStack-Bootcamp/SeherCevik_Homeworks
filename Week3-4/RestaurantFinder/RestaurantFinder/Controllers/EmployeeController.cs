using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantFinder.DataAccess;
using RestaurantLibrarys.Entities.DTO;
using RestaurantLibrarys.Entities.EntitiesModels;

namespace RestaurantFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly RestaurantDbContext _context;

        public EmployeeController(RestaurantDbContext context)
        {
            _context = context;
        }
        //public List<Employee> EmployeeList = new List<Employee>()
        //{
        //    new Employee{Id=1,name="Aybike",LastName="pusat",RestaurantId=1 },
        //    new Employee{Id=2,name="Tamer",LastName="böcek",RestaurantId=2},
        //    new Employee{Id=3,name="Seher",LastName="Stark",RestaurantId=3},
        //    new Employee{Id=4,name="Hatice",LastName="Netice",RestaurantId=4},
        //    new Employee{Id=5,name="Hüsnü",LastName="Mübarek",RestaurantId=5}

        //};
        Result _result = new Result();
        [HttpGet("GelAllEmp")]
        public Result GelAllEmployee()
        {
            var employeeList = _context.employees.ToList();
            if (employeeList.Count > 0)
            {
                _result.Status = 1;
                _result.message = "Employee of list";
                _result.EmployeeList = employeeList;

            }   
            else
            {
                _result.Status = 0;
                _result.message = "No record found";

            }
            return _result;
        }
        [HttpGet("{Id}")]
        public Result GetEmployee(int Id)
        {
            //Employee emp = EmployeeList[Id];
            var employee = _context.employees.Where(Employee => Employee.Id == Id).ToList();
            if (employee.Count > 0)
            {
                _result.Status = 1;
                _result.message = "Employye record found";
                _result.EmployeeList = employee;
            }
            else
            {
                _result.Status = 0;
                _result.message = "No employee records";
            }
            return _result;
        }

        //Kayıt eklemek için 
        [HttpPost("AddEmployee")]
        public Result AddEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO is not null)
            {
                var employee = new Employee()
                {
                    name = employeeDTO.name,
                    LastName = employeeDTO.LastName,    
                    RestaurantId = employeeDTO.RestaurantId
                };

                _context.employees.Add(employee);
                _context.SaveChanges();
                _result.Status = 1;
                _result.message = "Registration successfully added";

            }
            else
            {
                _result.Status = 0;
                _result.message = "Failed to add record";
            }
            return _result;
        }

        //güncelleme yapacak metod
        [HttpPut("{Id}")]
        public Result Update(int Id, EmployeeDTO employeeDTO)
        {
            Employee? employee = _context.employees.FirstOrDefault(o => o.Id == Id);
            if (employee != null)
            {
                employee.name = employeeDTO.name;
                employee.LastName = employeeDTO.LastName;
                employee.RestaurantId = employeeDTO.RestaurantId;

                _context.SaveChanges();

                _result.Status = 1;
                _result.message = "Employee information updated";
            }
            else
            {
                _result.Status = 0;
                _result.message = "This Employee information is not registered";
            }
            return _result;
        }

        //silme işlemi yapacak metod
        [HttpDelete("{Id}")]
        public Result Delete(int Id)
        {
            //var customer = CustomerList.FirstOrDefault(k => k.Id == Id);
            var Employee = _context.employees.FirstOrDefault(k => k.Id == Id);
            if (Employee is not null)
            {
                _context.employees.Remove(Employee);
                _context.SaveChanges();
                _result.Status = 1;
                _result.message = "This record has been deleted";
            }
            else
            {
                _result.Status = 0;
                _result.message = "This record not found";
            }
            return _result;

        }
    }
}

using EmployeesWorld.Repositories;

namespace EmployeesWorld.Models
{
    public class Admin : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

using EmployeesWorld.Repositories;

namespace EmployeesWorld.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public int EmployeeId { get; set; }
    }
}

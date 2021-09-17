using EmployeesWorld.Repositories;
using System.Collections.Generic;

namespace EmployeesWorld.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public Communication Communication { get; set; }
        public List<Skill> Skill { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
    }
}

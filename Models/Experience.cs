using EmployeesWorld.Repositories;

namespace EmployeesWorld.Models
{
    public class Experience : BaseEntity
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public bool isCurrent { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

using EmployeesWorld.Repositories;

namespace EmployeesWorld.Models
{
    public class Communication : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string EMailAdress { get; set; }
        public string Adress { get; set; }
        public string LinkedinAdress { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}

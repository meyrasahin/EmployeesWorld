using EmployeesWorld.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesWorld.Models
{
    public class Education : BaseEntity
    {
        public string SchoolName{ get; set; }
        public string Degree{ get; set; }
        public string DepartmentName{ get; set; }
        public string StartDate{ get; set; }
        public string EndDate{ get; set; }
        public int Average { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

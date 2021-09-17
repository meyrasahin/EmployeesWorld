using EmployeesWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesWorld.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public List<Skill> GetSkills(int id)
        {
            var item = GenericRepository<Employee>.context.Set<Skill>().Where(x => x.EmployeeId == id).ToList();
            return item;
        }

        public Communication GetContact(int id)
        {
            var item = GenericRepository<Employee>.context.Set<Communication>().Where(x => x.EmployeeId == id).FirstOrDefault();
            return item;
        }

        public List<Experience> GetExperiences(int id)
        {
            var item = GenericRepository<Employee>.context.Set<Experience>().Where(x => x.EmployeeId == id).ToList();
            return item;
        }

        public List<Education> GetEducations(int id)
        {
            var item = GenericRepository<Employee>.context.Set<Education>().Where(x => x.EmployeeId == id).ToList();
            return item;
        }
    }
}

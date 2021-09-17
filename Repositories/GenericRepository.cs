using EmployeesWorld.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesWorld.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        public static Context context;

        public List<T> TList()
        {
            context = new Context();
            return context.Set<T>().AsNoTracking().ToList();
        }

        public void TAdd(T item)
        {
            context = new Context();
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void TDelete(T item)
        {
            context = new Context();
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public void TUpdate(Employee item)
        {
            context = new Context();


            for (int i = 0; i < item.Skill.Count(); i++)
            {
                var deletedskill = context.Skills.Where(a => a.EmployeeId == item.Id).FirstOrDefault();
                context.Skills.Remove(deletedskill);
                Skill newSkill = new Skill();
                newSkill.EmployeeId = item.Id;
                newSkill.Name = item.Skill[i].Name;
                if (i == 0)
                {
                    List<Skill> emptySkill = new List<Skill>();
                    item.Skill = emptySkill;
                }
                context.Skills.Add(newSkill);
            }

            var deletedCom = context.Communications.Where(a => a.EmployeeId == item.Id).FirstOrDefault();
            context.Communications.Remove(deletedCom);
            Communication newCom = new Communication();
            newCom.PhoneNumber = item.Communication.PhoneNumber;
            newCom.EMailAdress = item.Communication.EMailAdress;
            newCom.Adress = item.Communication.Adress;
            newCom.LinkedinAdress = item.Communication.LinkedinAdress;
            newCom.EmployeeId = item.Id;
            item.Communication = newCom;
            context.Communications.Add(newCom);


            for (int i = 0; i < item.Education.Count(); i++)
            {
                var deletedEdu = context.Educations.Where(a => a.EmployeeId == item.Id).FirstOrDefault();
                context.Educations.Remove(deletedEdu);
                Education newEdu = new Education();
                newEdu.SchoolName = item.Education[i].SchoolName;
                newEdu.Degree = item.Education[i].Degree;
                newEdu.DepartmentName = item.Education[i].DepartmentName;
                newEdu.StartDate = item.Education[i].StartDate;
                newEdu.EndDate = item.Education[i].EndDate;
                newEdu.Average = item.Education[i].Average;
                newEdu.EmployeeId = item.Id;
                if (i == 0)
                {
                    List<Education> emptyEdu = new List<Education>();
                    item.Education = emptyEdu;
                }
                context.Educations.Add(newEdu);
            }


            for (int i = 0; i < item.Experience.Count(); i++)
            {
                var deletedEx = context.Experiences.Where(a => a.EmployeeId == item.Id).FirstOrDefault();
                context.Experiences.Remove(deletedEx);
                Experience newEx = new Experience();
                newEx.Title = item.Experience[i].Title;
                newEx.CompanyName = item.Experience[i].CompanyName;
                newEx.isCurrent = item.Experience[i].isCurrent;
                newEx.StartDate = item.Experience[i].StartDate;
                newEx.EndDate = item.Experience[i].EndDate;
                newEx.EmployeeId = item.Id;
                if (i == 0)
                {
                    List<Experience> emptyEx = new List<Experience>();
                    item.Experience = emptyEx;
                }
                context.Experiences.Add(newEx);
            }


            context.Employees.Update(item);
            context.SaveChanges();
        }

        public T TGetItem(int id)
        {
            context = new Context();
            var item = context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            return item;
        }




    }
}

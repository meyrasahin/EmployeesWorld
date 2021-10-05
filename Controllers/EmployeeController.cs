using EmployeesWorld.Models;
using EmployeesWorld.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeesWorld.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository repo = new EmployeeRepository();

        [AllowAnonymous]
        public IActionResult Index()
        {
            try
            {
                return View(repo.TList());
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message.ToString());
            }
        }
        
        [AllowAnonymous]
        public IActionResult ListDepartments()
        {
            ViewBag.allEmployees = repo.TList();
            return View(getTitles(repo.TList()));
        }

        private List<string> getTitles(List<Employee> liste)
        {
            var toBeReturned = new List<string>();
            foreach (var item in liste)
            {
                if (!toBeReturned.Contains(item.Title))
                {
                    toBeReturned.Add(item.Title);
                }
            }
            return toBeReturned;
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var item = repo.TGetItem(id);
            item.Skill = repo.GetSkills(id);
            item.Communication = repo.GetContact(id);
            item.Education = repo.GetEducations(id);
            item.Experience = repo.GetExperiences(id);
            return View(item);
        }
        
        public IActionResult Delete(int id)
        {
            var employee = repo.TGetItem(id);
            repo.TDelete(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee item)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            repo.TAdd(item);
            item.Education[0].EmployeeId = item.Id;
            item.Experience[0].EmployeeId = item.Id;
            item.Skill[0].EmployeeId = item.Id;
            item.Communication.EmployeeId = item.Id;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = repo.TGetItem(id);
            item.Skill = repo.GetSkills(id);
            item.Communication = repo.GetContact(id);
            item.Education = repo.GetEducations(id);
            item.Experience = repo.GetExperiences(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Employee item)
        {
            repo.TUpdate(item);

            return RedirectToAction("Index", "Employee");
        }
    }
}

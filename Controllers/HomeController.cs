using EmployeesWorld.Models;
using EmployeesWorld.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EmployeesWorld.Controllers
{
    
    public class HomeController : Controller
    {
        EmployeeRepository repo = new EmployeeRepository();
        [AllowAnonymous]
        public IActionResult Index(int page = 1, string name = "", string department = "", string location = "")
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult GetFilters(EmployeeFilter filter)
        {
            
            if (string.IsNullOrEmpty(filter.NameFilter) && string.IsNullOrEmpty(filter.TitleFilter) && string.IsNullOrEmpty(filter.LocationFilter))
            {
                var data = new List<Employee>();
                return Json(data);
            }
            else
            {
                if (string.IsNullOrEmpty(filter.NameFilter))
                {
                    filter.NameFilter = "";
                }
                if (string.IsNullOrEmpty(filter.TitleFilter))
                {
                    filter.TitleFilter = "";
                }
                if (string.IsNullOrEmpty(filter.LocationFilter))
                {
                    filter.LocationFilter = "";
                }
                var data = repo.TList()
                    .Where(x => x.Name.ToLower().Contains(filter.NameFilter.ToLower()) 
                    && x.Title.ToLower().Contains(filter.TitleFilter.ToLower()) 
                    && x.Location.ToLower().Contains(filter.LocationFilter.ToLower()))
                    .ToList();
                return Json(data);
            }
            
        }
    }
}

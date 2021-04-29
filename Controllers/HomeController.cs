using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                                IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var allstaff = _employeeRepository.GetAllEmployee();
            return View(allstaff);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                id = employee.Id,
                Email= employee.Email,
                Phone=employee.Phone,
                Name=employee.Name,
                statelist=employee.statelist,
                Gender=employee.Gender,
                Department=employee.Department,
                ExistingPhotoPath=employee.photopath,
               
 

            };

            return View(employeeEditViewModel);
           
        }

        public IActionResult Delete(int id)
        {
           // Employee emp = _employeeRepository.GetEmployee(id);
            return View();

        }

        public IActionResult Details(int id)
        {
            HomeGetDetailsViewModel homeGetDetailsViewModel = new HomeGetDetailsViewModel()
            {
                // employee, pageTitle, newEployee

                newEmployee = _employeeRepository.GetEmployee(id),
                PageTitle = "Bello is the Student Details: "
                


            };

          //  Employee emp = _employeeRepository.GetEmployee(id);
            return View(homeGetDetailsViewModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo !=null)
                {    //getting file path(folder inside wwwroot)
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");

                    //making the image name unique
                   uniqueFileName= Guid.NewGuid().ToString()+"_"+Path.GetFileName(model.Photo.FileName);
                    string filePath=Path.Combine(uploadsFolder, uniqueFileName);
                    //string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                 using(FileStream fs= new FileStream(filePath, FileMode.Create))
                    {
                        model.Photo.CopyTo(fs);
                    }

                }

                Employee newEmployee = new Employee
                {
                    Name= model.Name,
                    Email=model.Email,
                    Phone=model.Phone,
                    Department=model.Department,
                    statelist=model.statelist,
                    Gender=model.Gender,
                    photopath= uniqueFileName

                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }


            return View();
        
        
        }



        //the methos bellow is use with Employee Model 
            /*public IActionResult Create(Employee employee)
            {

                if(ModelState.IsValid)
                {
                    Employee newEmployee = _employeeRepository.Add(employee);
                    return RedirectToAction("Details", new { id = newEmployee.Id });
                }

                return View();

            }*/

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

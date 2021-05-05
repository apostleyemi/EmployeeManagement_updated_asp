using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IWebHostEnvironment iWebHostEnvironment;
        

        public HomeController(IEmployeeRepository employeeRepository,
                                IWebHostEnvironment iWebHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.iWebHostEnvironment = iWebHostEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var allstaff = _employeeRepository.GetAllEmployee();
            return View(allstaff);
        }

        [HttpGet]
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

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.id);

                employee.Name = model.Name;
                employee.Phone = model.Phone;
                employee.statelist = model.statelist;
                employee.Department = model.Department;
                employee.Email = model.Email;
                employee.Gender = model.Gender;

                if (model.Photo != null)
                {

                    //this method checks for previous uploaded photo from Upload
                    if(model.ExistingPhotoPath !=null)
                    {

                       string filePath= Path.Combine(iWebHostEnvironment.WebRootPath, "Uploads", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // ProcessUploadFile is a function that uploads phot to the uploads folder
                    //this methos is use by edit and create method
                    //Note edit collect from EmployeeEditViewModel while create receives from EmployeeCreateViewModel
                    //the ProcessUploadFile receives from EmployeeCreateViewModel being the parent class for EmployeeEditViewModel
                    employee.photopath = ProcessUploadFile(model);
                }

              
                _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }


            return View();


        }
         
        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {    //getting file path(folder inside wwwroot)
                string uploadsFolder = Path.Combine(iWebHostEnvironment.WebRootPath, "Uploads");

                //making the image name unique
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fs);
                }

            }

            return uniqueFileName;
        }

        public IActionResult Delete(int id)
        {
           // Employee emp = _employeeRepository.GetEmployee(id);
            return View();

        }

        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            //id can be int or not int
           // throw new Exception("Error in Details View");

            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeGetDetailsViewModel homeGetDetailsViewModel = new HomeGetDetailsViewModel()
            {
                // employee, pageTitle, newEployee

                newEmployee = _employeeRepository.GetEmployee(id.Value),
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
                string uniqueFileName = ProcessUploadFile(model);

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
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

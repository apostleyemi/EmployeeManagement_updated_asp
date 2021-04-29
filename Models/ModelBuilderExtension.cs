using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                 new Employee
                 {
                     Id = 1,
                     Name = "Dayo",
                     Department = Dept.IT,
                     Email = "dayo@techspace.com.ng",
                     Phone = "08067013148",
                     Gender = Gender.Male,
                     statelist = Statelist.Lagos,
                 },


                new Employee
                {
                    Id = 2,
                    Name = "John",
                    Department = Dept.IT,
                    Email = "john@techspace.com.ng",
                    Phone = "08067013148",
                    Gender = Gender.Male,
                    statelist = Statelist.Abia,
                },

                new Employee
                {
                    Id = 3,
                    Name = "Mary",
                    Department = Dept.HR,
                    Email = "mary@techspace.com.ng",
                    Phone = "08067013148",
                    Gender = Gender.Female,
                    statelist = Statelist.Oyo,
                },

                new Employee
                {
                    Id = 4,
                    Name = "Abiodun",
                    Department = Dept.ACCADEMIC,
                    Email = "abiodun@techspace.com.ng",
                    Phone = "08067013148",
                    Gender = Gender.Male,
                    statelist = Statelist.Osun,
                }

                );
        }
    }
}

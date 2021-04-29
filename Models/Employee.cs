using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fullname :")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        ErrorMessage = "Please enter a valid e-mail adress")]
        [Display(Name="Office Email: ")]
        public string Email { get; set; }
       
       
        [Required]
        public string Phone { get; set; }
        [Required]
        public Dept Department { get; set; }
        [Required]
        public Statelist statelist { get; set; }

        [Required]

        public Gender Gender { get; set; }
        public string photopath { get; set; }


    }
}

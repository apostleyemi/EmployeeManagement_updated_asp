using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EditRoleVIewModel
    {
        public EditRoleVIewModel()
        {
            Users = new List<string>();
        }
        [Display(Name ="Role ID")]
        public string Id { get; set; }

        [Required(ErrorMessage ="Role name cannot be empty")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIDemonstration_1.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int DeptId { get; set; }
    }
}
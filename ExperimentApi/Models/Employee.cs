using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExperimentApi.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Emp_Name { get; set; }
        public int Emp_Salary { get; set; }
        public string Emp_Location { get; set; }
        public int Dept_ID { get; set; }
    }
}
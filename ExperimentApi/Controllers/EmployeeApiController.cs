using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExperimentApi.Contracts;
using ExperimentApi.Models;

namespace ExperimentApi.Controllers
{
    public class EmployeeApiController : ApiController
    {
       /* public List<Employee> Get()
        {
            EmpRepository er = new EmpRepository();
            return er.GetAll();
        }*/
        public Employee Get(int ID)
        {
            EmpRepository er = new EmpRepository();
            return er.Get(ID);
        }
        [Route("api/EmployeeApi/name")]
        [HttpPost]
        public bool Post(Employee emp)
        {
            EmpRepository er = new EmpRepository();
            return er.Post(emp);
        }
        [Route("api/EmployeeApi/name")]
        [HttpPost]
        public bool Delete(int ID)
        {
            EmpRepository er = new EmpRepository();
            return er.Delete(ID);
        }
        [Route("api/EmployeeApi/ravi")]
        [HttpPost]
        public bool Update(Employee emp)
        {
            EmpRepository er = new EmpRepository();
            return er.Update(emp);
        }
        [Route("api/EmployeeApi/kumar")]
        [HttpPost]
        public bool Patch(Employee emp)
        {
            EmpRepository er = new EmpRepository();
            return er.Patch(emp);
        }

    }
}

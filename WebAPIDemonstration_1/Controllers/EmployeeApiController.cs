using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIDemonstration_1.Contracts;
using WebAPIDemonstration_1.Models;

namespace WebAPIDemonstration_1.Controllers
{
    [EnableCors("http://localhost:4200","*","*")]
    public class EmployeeApiController : ApiController
    {
        IEmployeeRepository repo;

        public EmployeeApiController(IEmployeeRepository repository)
        {
            repo = repository;
        }
        public List<Employee> Get()
        {
            return repo.GetAll();
        }

        public Employee Get(int Id)
        {
            return repo.Get(Id);
        }

        //public bool Post(Employee emp)
        //{
        //    EmployeeRepository repo = new EmployeeRepository();

        //    return repo.Create(emp);
        //}

        //[HttpPost]
        //public bool Create(Employee emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return repo.Create(emp);
        //    }
        //    else
        //    {                
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }
        //}

        [HttpPost]
        public HttpResponseMessage Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, repo.Create(emp));
            }
            else
            {
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest,"Validation of the Data is Failed");
            }
        }

        public bool Put(Employee emp)
        {
            return repo.Update(emp);
        }

        public bool Delete(int Id)
        {
            return repo.Delete(Id);
        }
    }
}

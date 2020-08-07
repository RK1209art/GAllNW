using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemonstration_1.Controllers
{
    public class TestApiController : ApiController
    {
        public List<string> GetAll()
        {
            return new List<string>
            {
                "Asp.Net MVC","Asp.Net Web API","Entity Framewprk","Asp.Net Core"
            };
        }
    }
}

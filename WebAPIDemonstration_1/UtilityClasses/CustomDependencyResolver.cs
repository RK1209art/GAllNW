using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using WebAPIDemonstration_1.Contracts;
using WebAPIDemonstration_1.Models;

namespace WebAPIDemonstration_1.UtilityClasses
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        UnityContainer unity;

        public CustomDependencyResolver()
        {
            unity = new UnityContainer();

            unity.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            //unity.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return unity.Resolve(serviceType);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unity.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
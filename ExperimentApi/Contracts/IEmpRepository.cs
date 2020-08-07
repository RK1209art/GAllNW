using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentApi.Models;

namespace ExperimentApi.Contracts
{
        public interface IEmpRepository
        {
            List<Employee> GetAll();

            Employee Get(int ID);

            bool Post(Employee emp);

            bool Update(Employee emp);
            bool Patch(Employee emp);

            bool Delete(int ID);
        }
}

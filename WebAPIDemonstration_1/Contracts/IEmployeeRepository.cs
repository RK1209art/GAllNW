using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemonstration_1.Models;

namespace WebAPIDemonstration_1.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee Get(int Id);

        bool Create(Employee emp);

        bool Update(Employee emp);

        bool Delete(int Id);
    }
}

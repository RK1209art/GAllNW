using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using WebAPIDemonstration_1.Contracts;

namespace WebAPIDemonstration_1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {        
        public List<Employee> GetAll()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString);
            string query = "select * from dbo.Employee";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            List<Employee> empList = new List<Employee>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    DeptId = (int)dr[4]
                };

                empList.Add(emp);
            }

            conn.Close();

            return empList;
        }

        public Employee Get(int Id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString);
            string query = "select * from dbo.Employee where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            conn.Open();
            Employee emp = null; ;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                emp = new Employee
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = (int)dr[3],
                    DeptId = (int)dr[4]
                };
            }
            conn.Close();
            return emp;
        }

        public bool Create(Employee emp)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString);
            string query = "insert into dbo.Employee(Id, Name, Location, Salary, DeptId) values(@id,@name,@loc,@sal,@deptId)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@loc", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@sal", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@deptId", emp.DeptId));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (noOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString);
            string query = "delete from dbo.Employee where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (noOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        public bool Update(Employee emp)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString);
            string query = "update dbo.Employee set Name=@name, Location=@loc, Salary=@sal, DeptId=@deptId where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@loc", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@sal", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@deptId", emp.DeptId));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (noOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
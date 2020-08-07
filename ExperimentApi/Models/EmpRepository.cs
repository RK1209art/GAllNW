using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using ExperimentApi.Contracts;

namespace ExperimentApi.Models
{
    public class EmpRepository:IEmpRepository
    {
        public List<Employee> GetAll()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from dbo.Emp_details", con);
            con.Open();
            List<Employee> empList = new List<Employee>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee
                {
                    ID = (int)dr[0],
                    Emp_Name = dr[1].ToString(),
                    Emp_Salary = (int)dr[2],
                    Emp_Location = dr[3].ToString(),
                    Dept_ID = (int)dr[4]

                };

                empList.Add(emp);
            }
            con.Close();
            return empList;
        }
        public Employee Get(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from dbo.Emp_details where ID= @ID", con);
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            con.Open();
            List<Employee> emplist = new List<Employee>();
            SqlDataReader dr = cmd.ExecuteReader();
            Employee emp = null;
            if (dr.Read())
            {
                emp = new Employee
                {
                    ID = (int)dr[0],
                    Emp_Name = dr[1].ToString(),
                    Emp_Salary = (int)dr[2],
                    Emp_Location = dr[3].ToString(),
                    Dept_ID = (int)dr[4]

                };
            }
            con.Close();
            return emp;
        }
        public bool Post(Employee emp)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Insert into dbo.Emp_details(ID,Emp_Name,Emp_Salary,Emp_Location,Dept_ID) Values(@ID,@Name,@Sal,@Loc,@Dept_ID)", con);
            cmd.Parameters.Add(new SqlParameter("@ID", emp.ID));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Emp_Name));
            cmd.Parameters.Add(new SqlParameter("@Sal", emp.Emp_Salary));
            cmd.Parameters.Add(new SqlParameter("@Loc", emp.Emp_Location));
            cmd.Parameters.Add(new SqlParameter("@Dept_ID", emp.Dept_ID));
            con.Open();
            int noOfRowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (noOfRowAffected > 0)
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Update dbo.Emp_Details set Emp_Name=@Name, Emp_Salary=@Sal, Emp_Location=@Loc,Dept_ID=@Dept_ID where ID=@ID", con);
            cmd.Parameters.Add(new SqlParameter("@ID", emp.ID));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Emp_Name));
            cmd.Parameters.Add(new SqlParameter("@Sal", emp.Emp_Salary));
            cmd.Parameters.Add(new SqlParameter("@Loc", emp.Emp_Location));
            cmd.Parameters.Add(new SqlParameter("@Dept_ID", emp.Dept_ID));
            con.Open();
            int noOfRowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (noOfRowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Patch(Employee emp)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Update dbo.Emp_Details set Emp_Name=@Name where ID=@ID", con);
            cmd.Parameters.Add(new SqlParameter("@ID",emp.ID));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Emp_Name));
            con.Open();
            int noOfRowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (noOfRowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Delete from dbo.Emp_details where ID =@ID", con);
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            con.Open();
            int noOfRowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (noOfRowAffected > 0)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CrudAppusingAdo.Models
{
    public class EmployeeDbContext 
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Employee> GetEmployees()
        {
            List<Employee> employeesList=new List<Employee>();
            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.id = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.name = dr.GetValue(1).ToString();
                emp.gender = dr.GetValue(2).ToString();             
                emp.age = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                emp.city = dr.GetValue(5).ToString();
                employeesList.Add(emp);
            }
            con.Close();
            return employeesList;

        }
        public bool AddEmployees(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender",emp.gender);
            cmd.Parameters.AddWithValue("@age",emp.age);
            cmd.Parameters.AddWithValue("salary",emp.salary);
            cmd.Parameters.AddWithValue("@city",emp.city);
            con.Open();
            int i=  cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmployees(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",emp.id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
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
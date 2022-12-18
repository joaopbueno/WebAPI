using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT DepartmentId, DepartmentName FROM Department";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using(var cmd =new SqlCommand(query,con))
                using (var da= new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {
                string query =@"INSERT INTO Department VALUES ('"+dep.DepartmentName+@"')";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
            }
            catch (Exception)
            {
                return "Failed to Add!!";
            }

            return "Added Successfully!!";
        }

        public string Put(Department dep)
        {
            try
            {
                string query = @"UPDATE Department SET DepartmentName = '" + dep.DepartmentName + @"' 
                                 WHERE DepartmentId = "+dep.DepartmentId+"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
            }
            catch (Exception)
            {
                return "Failed to updated!!";
            }

            return "Updated Successfully!!";
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM Department  
                                 WHERE DepartmentId = " + id + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
            }
            catch (Exception)
            {
                return "Failed to deleted!!";
            }

            return "Deleted Successfully!!";
        }
    }
}

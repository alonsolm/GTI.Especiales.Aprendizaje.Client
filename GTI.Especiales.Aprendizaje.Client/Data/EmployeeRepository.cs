using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GTI.Especiales.Aprendizaje.Client.Models;
using GTI.Especiales.Aprendizaje.Client.Common;

namespace GTI.Especiales.Aprendizaje.Client.Data
{
    public class EmployeeRepository
    {
        private const string CREATE_NAME_STORED_PROCEDURE = "Employee_Create";
        private const string UPDATE_NAME_STORED_PROCEDURE = "Employee_Update";

        private string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }

        public Result AddEmployee(Employee employee)
        {
            Result result = Helpers.Success;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(CREATE_NAME_STORED_PROCEDURE, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);

                    sqlCommand.Parameters.AddWithValue("@RFC", employee.RFC);

                    SqlParameter salaryParam = new SqlParameter("@Salary", SqlDbType.Decimal);
                    salaryParam.Precision = 18;
                    salaryParam.Scale = 2;
                    salaryParam.Value = employee.Salary;
                    sqlCommand.Parameters.Add(salaryParam);

                    sqlCommand.Parameters.AddWithValue("@Active", employee.Active);

                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
                    sqlCommand.Parameters["@EmployeeID"].Direction = ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        
                        sqlCommand.ExecuteNonQuery();
                        
                        employee.EmployeeID = (int)sqlCommand.Parameters["@EmployeeID"].Value;
                        
                    }
                    catch (Exception e)
                    {
                        result = Helpers.OnError(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return result;
        }

        public Result UpdateEmployee(Employee employee)
        {
            Result result = Helpers.Success;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(UPDATE_NAME_STORED_PROCEDURE, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                    sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);

                    sqlCommand.Parameters.AddWithValue("@RFC", employee.RFC);

                    SqlParameter salaryParam = new SqlParameter("@Salary", SqlDbType.Decimal);
                    salaryParam.Precision = 18;
                    salaryParam.Scale = 2;
                    salaryParam.Value = employee.Salary;
                    sqlCommand.Parameters.Add(salaryParam);

                    sqlCommand.Parameters.AddWithValue("@Active", employee.Active);


                    try
                    {
                        connection.Open();

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        result = Helpers.OnError(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return result;
        }

        public Result DeleteEmployee(int employeeID)
        {
            Result result = Helpers.Success;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(UPDATE_NAME_STORED_PROCEDURE, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

                    sqlCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit));
                    sqlCommand.Parameters["@Active"].Value = false;


                    try
                    {
                        connection.Open();

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        result = Helpers.OnError(e.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return result;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            var queryDb = @"SELECT * FROM Employee";
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(queryDb, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();
                    FromDbResultToEmployee(reader, employee);
                    employees.Add(employee);
                }
            }
            catch
            {
            }

            return employees;
        }

        public Employee GetEmployeeById(int employeeID)
        {
            var queryDb = @"SELECT * FROM Employee WHERE EmployeeID = @employeeID";

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(queryDb, connection);
            sqlCommand.Parameters.Add(new SqlParameter("@employeeID", employeeID));
            connection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            Employee employee = new Employee();

            if (reader.Read()) {
                FromDbResultToEmployee(reader, employee);
            }

            return employee;
        }

        private void FromDbResultToEmployee(SqlDataReader reader, Employee employee)
        {
            employee.EmployeeID = (int)reader["EmployeeID"];
            employee.EmployeeName = (string)reader["EmployeeName"];
            employee.RFC = (string)reader["RFC"];
            employee.Salary = (decimal)reader["Salary"];
            employee.Active = (bool)reader["Active"];
        }
    }
}
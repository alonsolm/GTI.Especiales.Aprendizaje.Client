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
        private const string CREATE_NAME_STORED_PROCEDURE = "Employe_Create";
        private const string UPDATE_NAME_STORED_PROCEDURE = "Employe_Update";

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

                    sqlCommand.Parameters.AddWithValue("@EmployeName", employee.EmployeName);

                    sqlCommand.Parameters.AddWithValue("@RFC", employee.RFC);

                    SqlParameter salaryParam = new SqlParameter("@Salary", SqlDbType.Decimal);
                    salaryParam.Precision = 18;
                    salaryParam.Scale = 2;
                    salaryParam.Value = employee.Salary;
                    sqlCommand.Parameters.Add(salaryParam);

                    sqlCommand.Parameters.AddWithValue("@Active", employee.Active);

                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeID", SqlDbType.Int));
                    sqlCommand.Parameters["@EmployeID"].Direction = ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        
                        sqlCommand.ExecuteNonQuery();
                        
                        employee.EmployeID = (int)sqlCommand.Parameters["@EmployeID"].Value;
                        
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

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(UPDATE_NAME_STORED_PROCEDURE, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeID", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@EmployeID"].Value = employee.EmployeID;

                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeName", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@EmployeName"].Value = employee.EmployeName;

                    sqlCommand.Parameters.Add(new SqlParameter("@RFC", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@RFC"].Value = employee.RFC;

                    sqlCommand.Parameters.Add(new SqlParameter("@Salary", SqlDbType.Decimal));
                    sqlCommand.Parameters["@Salary"].Value = employee.Salary;

                    sqlCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit));
                    sqlCommand.Parameters["@Active"].Value = employee.Active;
                    

                    try
                    {
                        connection.Open();
                        
                        sqlCommand.ExecuteNonQuery();
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void DeleteEmployee(int employeID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(UPDATE_NAME_STORED_PROCEDURE, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeID", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@EmployeID"].Value = employeID;

                    sqlCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit));
                    sqlCommand.Parameters["@Active"].Value = false;


                    try
                    {
                        connection.Open();

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var queryDb = @"SELECT * FROM Employe";
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(queryDb, connection);
            connection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Employee> customers = new List<Employee>();
            while (reader.Read())
            {
                Employee entity = new Employee();
                entity.EmployeID = (int)reader["EmployeID"];
                entity.EmployeName = (string)reader["EmployeName"];
                entity.RFC = (string)reader["RFC"];
                entity.Salary = (Decimal)reader["Salary"];
                entity.Active = (Boolean)reader["Active"];
                customers.Add(entity);
            }
            
            return customers;
        }

        public Employee GetEmployeeById(int employeID)
        {
            var queryDb = @"SELECT * FROM Employe WHERE EmployeID = @employeID";

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand(queryDb, connection);
            sqlCommand.Parameters.Add(new SqlParameter("@employeID", employeID));
            connection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            Employee employee = new Employee();

            if (reader.Read()) {
                employee.EmployeID = (int)reader["EmployeID"];
                employee.EmployeName = (string)reader["EmployeName"];
                employee.RFC = (string)reader["RFC"];
                employee.Salary = (Decimal)reader["Salary"];
                employee.Active = (Boolean)reader["Active"];
            }

            return employee;
        }

    }
}
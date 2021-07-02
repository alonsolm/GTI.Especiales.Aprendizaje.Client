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

namespace GTI.Especiales.Aprendizaje.Client.Data
{
    public class EmployeRepository
    {
        private string strcon = ConfigurationManager.ConnectionStrings["ServerConnection"].ConnectionString;
        public void AddEmploye(Employe employe)
        {
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Employe_Create", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeName", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@EmployeName"].Value = employe.EmployeName;

                    sqlCommand.Parameters.Add(new SqlParameter("@RFC", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@RFC"].Value = employe.RFC;

                    sqlCommand.Parameters.Add(new SqlParameter("@Salary", SqlDbType.Decimal));
                    sqlCommand.Parameters["@Salary"].Value = employe.Salary;

                    sqlCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit));
                    sqlCommand.Parameters["@Active"].Value = employe.Active;
                    
                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeID", SqlDbType.Int));
                    sqlCommand.Parameters["@EmployeID"].Direction = ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        
                        sqlCommand.ExecuteNonQuery();
                        
                        employe.EmployeID = (int)sqlCommand.Parameters["@EmployeID"].Value;
                        
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

        public void UpdateEmploye(Employe employe)
        {
            using (SqlConnection connection = new SqlConnection(strcon))
            {
                using (SqlCommand sqlCommand = new SqlCommand("Employe_Update", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeID", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@EmployeID"].Value = employe.EmployeID;

                    sqlCommand.Parameters.Add(new SqlParameter("@EmployeName", SqlDbType.NVarChar, 255));
                    sqlCommand.Parameters["@EmployeName"].Value = employe.EmployeName;

                    sqlCommand.Parameters.Add(new SqlParameter("@RFC", SqlDbType.NVarChar, 50));
                    sqlCommand.Parameters["@RFC"].Value = employe.RFC;

                    sqlCommand.Parameters.Add(new SqlParameter("@Salary", SqlDbType.Decimal));
                    sqlCommand.Parameters["@Salary"].Value = employe.Salary;

                    sqlCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit));
                    sqlCommand.Parameters["@Active"].Value = employe.Active;
                    

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

        public List<Employe> GetEmployes()
        {
            var queryDb = @"SELECT * FROM Employe";
            SqlConnection connection = new SqlConnection(strcon);
            SqlCommand sqlCommand = new SqlCommand(queryDb, connection);
            connection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Employe> customers = new List<Employe>();
            while (reader.Read())
            {
                Employe entity = new Employe();
                entity.EmployeID = (int)reader["EmployeID"];
                entity.EmployeName = (string)reader["EmployeName"];
                entity.RFC = (string)reader["RFC"];
                entity.Salary = (Decimal)reader["Salary"];
                entity.Active = (Boolean)reader["Active"];
                customers.Add(entity);
            }
            
            return customers;
        }

        public Employe GetEmployeById(int employeID)
        {
            var queryDb = @"SELECT * FROM Employe WHERE EmployeID = @employeID";

            SqlConnection connection = new SqlConnection(strcon);
            SqlCommand sqlCommand = new SqlCommand(queryDb, connection);
            sqlCommand.Parameters.Add(new SqlParameter("@employeID", employeID));
            connection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            Employe employe = new Employe();

            if (reader.Read()) {
                employe.EmployeID = (int)reader["EmployeID"];
                employe.EmployeName = (string)reader["EmployeName"];
                employe.RFC = (string)reader["RFC"];
                employe.Salary = (Decimal)reader["Salary"];
                employe.Active = (Boolean)reader["Active"];
            }

            return employe;
        }

    }
}
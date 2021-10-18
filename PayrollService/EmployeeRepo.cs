using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace PayrollService
{
    public class EmployeeRepo
    {

        public SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-NGODVI2\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True");

        public void GetAllEmployee()
        {
            try {
                EmployeeModel employeeModel = new EmployeeModel();
                
                connection.Open();
                //Query
                string sqlQuery = @"SELECT * FROM employee_payroll";

                SqlCommand cmd = new SqlCommand(sqlQuery,connection);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employeeModel.EmployeeID = dr.GetInt32(0);
                        employeeModel.EmployeeName = dr.GetString(1);
                        employeeModel.PhoneNumber = dr.GetString(2);
                        employeeModel.Address = dr.GetString(3);
                        employeeModel.Department = dr.GetString(4);
                        employeeModel.Gender = dr.GetString(5);
                        employeeModel.BasicPay = dr.GetDouble(6);
                        employeeModel.Deductions = dr.GetDouble(7);
                        employeeModel.TaxablePay = dr.GetDouble(8);
                        employeeModel.Tax = dr.GetDouble(9);
                        employeeModel.NetPay = dr.GetDouble(10);
                        employeeModel.StartDate = dr.GetDateTime(11);
                        employeeModel.City = dr.GetString(12);
                        employeeModel.Country = dr.GetString(13);
                        //Display one record
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}",employeeModel.EmployeeID,employeeModel.EmployeeName,employeeModel.BasicPay,employeeModel.StartDate);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No record in the table");
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetPayDetail()
        {
            try {
                EmployeeModel employeeModel = new EmployeeModel();
                connection.Open();
                string query = @"SELECT EmployeeName,BasicPay,Deductions,TaxablePay,Tax,NetPay FROM employee_payroll";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if(sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        employeeModel.EmployeeName = sqlDataReader.GetString(0);
                        employeeModel.BasicPay = sqlDataReader.GetDouble(1);
                        employeeModel.Deductions = sqlDataReader.GetDouble(2);
                        employeeModel.TaxablePay = sqlDataReader.GetDouble(3);
                        employeeModel.Tax = sqlDataReader.GetDouble(4);
                        employeeModel.NetPay = sqlDataReader.GetDouble(5);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",employeeModel.EmployeeName, employeeModel.BasicPay,
                            employeeModel.Deductions, employeeModel.TaxablePay,employeeModel.Tax, employeeModel.NetPay);
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateBasicPay(string name, float basicpay)
        {
            bool resultbol = false;
            try
            {
                //string connString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                //connection.ConnectionString = connString;
                using (SqlCommand command = new SqlCommand("spUpdateEmployeeBasicPay", this.connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ename", name);
                    command.Parameters.AddWithValue("@basicpay", basicpay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Employee {0} basic pay change to {1}", name, basicpay);
                        return resultbol = true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return resultbol;
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}

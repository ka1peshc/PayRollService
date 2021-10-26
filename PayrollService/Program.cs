using System;
using System.Configuration;
using System.Data.SqlClient;
using PayrollService.Model;

namespace PayrollService
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Payroll service");

            EmployeeModel employeeModel = new EmployeeModel();
            EmployeeRepo employeeRepo = new EmployeeRepo();

            employeeModel.EmployeeName = "Kalpesh";
            employeeModel.PhoneNumber = "9920036999";
            employeeModel.Address = "Sewri";
            employeeModel.Department = "Developer";
            employeeModel.Gender = "M";
            employeeModel.BasicPay=22000.00;
            employeeModel.Deductions = 1500.00;
            employeeModel.TaxablePay = 200.00;
            employeeModel.Tax = 300.00;
            employeeModel.NetPay = 25000.00;
            employeeModel.City = "Mumbai";
            employeeModel.Country = "India";

            //employeeRepo.GetAllEmployee();
            //employeeRepo.GetPayDetail();
            //employeeRepo.UpdateBasicPay("Terisa", 50000);
            //employeeRepo.DisplayEmployeeDetailBasedOnStartingDate(Convert.ToDateTime("2019/01/01"));
            //employeeRepo.DisplayAggregateQuery();

            EmployeeTransaction et = new EmployeeTransaction();
            PayrollModel ps = new PayrollModel();
            et.updateSalary(ps);
        }
    }
}

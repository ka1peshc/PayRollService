using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollService;
using PayrollService.Model;

namespace EmployeePayrollTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckIfUpdateSuccessfulOrNot()
        {
            bool expectedResult = true;

            EmployeeRepo ep = new EmployeeRepo();
            bool actualResult = ep.UpdateBasicPay("Terisa", 50000);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            //arrange
            EmployeeTransaction empTran = new EmployeeTransaction();
            PayrollModel updateModel = new PayrollModel()
            {
                EmpId = 4,
                BasicPay = 500000,
                Deduction = 100000,
                Taxable = 400000,
                Tax = 40000,
                NetPay = 460000
            };
            //Act
            float empSalary = empTran.updateSalary(updateModel);
            //Assert
            Assert.AreEqual(updateModel.BasicPay , empSalary);

        }
    }
}
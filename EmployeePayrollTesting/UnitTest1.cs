using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollService;

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
    }
}
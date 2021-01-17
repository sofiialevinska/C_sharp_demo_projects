using System;
using demo2_c_sharp_core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo2_ms_test
{
    [TestClass]
    public class Demo2XUnitTests
    {
        [TestMethod]
        public void TestMethod_GetAge()
        {
            //data
            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime(2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);

            //expected result
            int expected = 5;

            //actual result
            int actual = person.GetAge();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

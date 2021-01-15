using System;
using demo2_c_sharp_core;
using Xunit;

namespace demo2_x_unit_tests
{
    public class Demo2XUnitTests
    {
        [Fact]
        public void TestMethod_GetAge()
        {
            //data
            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime (2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);

            //expected result
            int expected = 21;

            //actual result
            int actual = person.GetAge();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Property ()
        {
            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime(2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);
        
            string newName = "Ivan";
            person.FirstName = newName;

            Assert.Equal(newName, person.FirstName);
        }

        [Fact]
        public void Test_Contains()
        {
            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime(2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);

            string substring = "Name";

            Assert.Contains(substring, person.FirstName);
        }
    }
}

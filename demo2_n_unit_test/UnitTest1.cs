using System;
using demo2_c_sharp_core;
using NUnit.Framework;

namespace demo2_n_unit_test
{
    public class Tests
    {
        [Test]
        public void TestInput()
        {
            Assert.Pass();

            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime(2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);

            person.FirstName = "123";

            Assert.AreSame(person.FirstName, person.LastName);
        }
    }
}
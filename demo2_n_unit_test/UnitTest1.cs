using System;
using demo2_c_sharp_core;
using NUnit.Framework;

namespace demo2_n_unit_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //data
            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime(2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);

            //expected result
            int expected = 21;

            //actual result
            int actual = person.GetAge();
        }

        [Test]
        public void TestInput()
        {
            Assert.Pass();

            //data
            int taxNumber = 111;
            string firstName = "firstName";
            string lastName = "lastName";
            DateTime birthDate = new DateTime(2000, 01, 15);
            Person person = new Person(taxNumber, firstName, lastName, birthDate);

            Assert.AreSame(person.FirstName, person.LastName);
        }
    }
}
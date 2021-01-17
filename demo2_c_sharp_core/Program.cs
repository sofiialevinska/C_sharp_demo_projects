using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace demo2_c_sharp_core
{
    [Serializable]
    class Program
    {
        private static string writePath = @"/Users/sofiiageletukha/Desktop/Coding/SETtest/hw/demo2/demo2/demo2_c_sharp_core/people_out.txt";
        private static string writeXmlPath = @"/Users/sofiiageletukha/Desktop/Coding/SETtest/hw/demo2/demo2/demo2_c_sharp_core/serialization.xml";

        private static Person RandomPerson()
        {
            Random rand = new Random();
            string randFirstName = RandomString();
            string randLastName = RandomString();
            int randTaxNumber = rand.Next(10000, 99999);
            int randYear = rand.Next(1900, DateTime.Now.Year);
            int randMonth = rand.Next(1, 12);
            int maxDaysInRandMonth = DateTime.DaysInMonth(randYear, randMonth);
            int randDay = rand.Next(1, maxDaysInRandMonth);
            DateTime randBirthDate = new DateTime(randYear, randMonth, randDay);
            return new Person(randTaxNumber, randFirstName, randLastName, randBirthDate);
        }

        private static Person RandomDoctor()
        {
            Random rand = new Random();
            string randFirstName = RandomString();
            string randLastName = RandomString();
            int randTaxNumber = rand.Next(10000, 1000000);
            int randDoctorPracticeStartAge = rand.Next(18, 40);
            int randYear = rand.Next(1940, DateTime.Now.Year - randDoctorPracticeStartAge);
            int randMonth = rand.Next(1, 12);
            int maxDaysInRandMonth = DateTime.DaysInMonth(randYear, randMonth);
            int randDay = rand.Next(1, maxDaysInRandMonth);
            DateTime randBirthDate = new DateTime(randYear, randMonth, randDay);
            int randYearOfStartPractice = rand.Next(randYear + randDoctorPracticeStartAge, DateTime.Now.Year);
            string randSpecialization = RandomString();
            Person person = new Doctor(randTaxNumber, randFirstName, randLastName, randBirthDate,
                randYearOfStartPractice, randSpecialization);
            return person;

        }

        private static string RandomString()
        {
            Random rand = new Random();
            int stringLength = rand.Next(4, 5);
            var builder = new StringBuilder(stringLength);
            char offsetLower = 'a';
            char offsetUpper = 'A';

            const int lettersOffset = 26;
            builder.Clear();
            for (var j = 0; j < stringLength; j++)
            {
                char @char;
                if (j == 0)
                {
                    @char = (char)rand.Next(offsetUpper, offsetUpper + lettersOffset);
                }
                else
                {
                    @char = (char)rand.Next(offsetLower, offsetLower + lettersOffset);
                }
                builder.Append(@char);
            }
            return builder.ToString();
        }

        public static void PrintAllElementsToConsole(List<Person> people, string outputTitle)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person.Output());
            }
            Console.WriteLine("\n_______________________________________________" +
                "________________________________________________________");
        }

        public static void PrintAllElementsToFile(List<Person> people, string outputTitle)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                {
                    sw.WriteLine(outputTitle + "\n");

                    foreach (var person in people)
                    {
                        sw.WriteLine(person.Output());
                    }

                    sw.WriteLine("\n_______________________________________________" +
                "________________________________________________________");
                }
            }
            catch
            {
                throw new Exception("Error with outputing data to file");
            }
        }

        public static void ClearFile()
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.WriteLine($"Date of running test: {DateTime.Now}");
            }
        }

        private static void SerializeListToXml(List<Person> people, XmlSerializer formatter)
        {
            using FileStream fs = new FileStream(writeXmlPath, FileMode.Create);
            formatter.Serialize(fs, people);
        }

        private static List<Person> DeserializeXmlToList(XmlSerializer formatter)
        {
            using FileStream fs = new FileStream(writeXmlPath, FileMode.Open);
            return ((List <Person>)formatter.Deserialize(fs)).ToList();
        }

        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int numPeople;

            //Create objects of Person type and input information about them
            //input v.1 - from Console
            Console.Write("\n\n\tPlease enter number of people you want to create.\nNumber of people = ");
            numPeople = Int32.Parse(Console.ReadLine());
            bool repeat = true;
            do
            {
                try
                {
                    for (int i = 0; i < numPeople; i++)
                    {
                        Person person = new Person();
                        person.Input();
                        people.Add(person);
                    }
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Error: Please enter data in right format. " + fex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Please try again");
                }
                finally
                {
                    Console.WriteLine("If you want to try entering data again press 'Y'");
                    string symbol = Console.ReadLine();
                    if (symbol == "Y")
                    {
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                    }
                }
            } while (repeat);

            try
            {
                //input v.2 -  automatically using class Random
                Console.Write("\n\n\tPlease enter number of people with random data you want to create.\nNumber of people = ");
                numPeople = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < numPeople; i++)
                {
                    people.Add(RandomPerson());
                }

                Console.Write("\n\tPlease enter number of doctors with random data you want to create.\nNumber of doctors = ");
                int numDoctors = Int32.Parse(Console.ReadLine());

                for (int i = 0; i < numDoctors; i++)
                {
                    people.Add(RandomDoctor());
                }

                //input v.3 -  manually
                people.Add(new Person(1111, "Ivan", "Abcd", new DateTime(1990, 12, 20)));
                people.Add(new Person(2222, "Ivan", "Абвг", new DateTime(1980, 3, 10)));
                people.Add(new Person(3333, "Ivan", "Бвгд", new DateTime(2000, 5, 5)));

                ClearFile();

                PrintAllElementsToConsole(people, "\n\n\tAll people in list:");
                PrintAllElementsToFile(people, "\n\n\tAll people in list:");

                var elder50Doctors =
                    (from person in people
                     where (person.GetAge() > 50) && (person.GetType() == typeof(Doctor))
                     select person).ToList();
                PrintAllElementsToConsole(elder50Doctors, "\n\n\tDoctors-therapists elder than 50 years:");
                PrintAllElementsToFile(elder50Doctors, "\n\n\tDoctors-therapists elder than 50 years:");

                people.Sort();

                PrintAllElementsToConsole(people, "\n\n\tList sorted by first name and last name:");
                PrintAllElementsToFile(people, "\n\n\tList sorted by first name and last name:");

                XmlSerializer formatter = new XmlSerializer(typeof(List <Person>));
                SerializeListToXml(people, formatter);
                List<Person> deserializedFromXmlPeople = DeserializeXmlToList(formatter);

                PrintAllElementsToConsole(deserializedFromXmlPeople, "\n\n\tList deserialized from xml:");
                PrintAllElementsToFile(deserializedFromXmlPeople, "\n\n\tList deserialized from xml:");
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("\nError: file not found. Please try again.\n" + fnfEx.Message);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("\nError: " + argEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);
            }
        }
    }
}

using System;
using System.Xml.Serialization;

namespace demo2_c_sharp_core
{
    [XmlInclude (typeof (Doctor))]
    [Serializable]
    public class Person : IComparable
    {
        private int taxNumber;
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private int personNumber;
        private int avgDaysInYear = 365;
        protected static int peopleCounter;

        public int TaxNumber
        {
            get
            {
                return this.taxNumber;
            }
            set
            {
                this.taxNumber = value;
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
            }
        }
        public int PersonNumber
        {
            get
            {
                return personNumber;
            }
            set
            {
                personNumber = value;
            }
        }

        public Person()
        {
            peopleCounter++;
            PersonNumber = peopleCounter;
        }

        public Person(int taxNumber, string firstName, string lastName, DateTime birthDate)
        {
            TaxNumber = taxNumber;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            peopleCounter++;
            PersonNumber = peopleCounter;
        }

        public virtual void Input()
        {
            Console.Write("\nPlease enter Person{0} Tax Number.\nPerson{0} Tax Number = ", PersonNumber);
            TaxNumber = Int32.Parse(Console.ReadLine());
            Console.Write("\nPlease enter Person{0} first name.\nPerson{0} First Name = ", PersonNumber);
            FirstName = Console.ReadLine();
            Console.Write("\nPlease enter Person{0} last name.\nPerson{0} Last Name = ", PersonNumber);
            LastName = Console.ReadLine();
            Console.Write("\nPlease enter Person{0} birthday date (year, month, day).\nPerson{0} birthday Year = ", PersonNumber);
            int birthYear = Int32.Parse(Console.ReadLine());
            Console.Write("Person{0} birthday Month = ", PersonNumber);
            int birthMonth = Int32.Parse(Console.ReadLine());
            Console.Write("Person{0} birthday Day = ", PersonNumber);
            int birthDay = Int32.Parse(Console.ReadLine());
            BirthDate = new DateTime(birthYear, birthMonth, birthDay);
        }

        public override string ToString()
        {
            return ("Tax: " + TaxNumber + "|\tFirstName: '" + FirstName +
                "'|\tLastName: '" + LastName + "'|\tBirthday: " +
                BirthDate.Day + "/" + BirthDate.Month + "/" + BirthDate.Year +
                "|\tAge: " + GetAge() + ".");
        }

        public virtual string Output()
        {
            return "\nPerson" + PersonNumber + ":\n" + ToString() +
                "\n. . . . . . . . . . . . . . . . . . . . . . . . " +
                ". . . . . . . . . . . . . . . . . . . . . . . . . . .";
        }

        public int GetAge()
        {
            return Convert.ToInt32(DateTime.Now.Subtract(BirthDate).Days / avgDaysInYear);
        }

        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            if (p != null)
            {
                if (FirstName != p.FirstName)
                {
                    return FirstName.CompareTo(p.FirstName);
                }
                else return LastName.CompareTo(p.LastName);
            }
            else
                throw new ArgumentException("Object is not a Person");
        }
    }
}

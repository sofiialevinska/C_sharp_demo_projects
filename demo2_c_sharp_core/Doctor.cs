using System;
using System.Xml.Serialization;

namespace demo2_c_sharp_core
{
    [XmlInclude(typeof(Doctor))]
    [Serializable]
    public class Doctor : Person
    {
        private int yearOfStartPractice;
        private string specialization;
        private int doctorNumber;

        public int YearOfStartPractice
        {
            get
            {
                return this.yearOfStartPractice;
            }
            set
            {
                this.yearOfStartPractice = value;
            }
        }
        public string Specialization
        {
            get
            {
                return this.specialization;
            }
            set
            {
                this.specialization = value;
            }
        }
        public int DoctorNumber
        {
            get
            {
                return this.doctorNumber;
            }
            set
            {
                this.doctorNumber = value;
            }
        }

        public Doctor()
        {
            DoctorNumber = peopleCounter;
        }

        public Doctor(int taxNumber, string firstName, string lastName, DateTime birthDate,
            int yearsPractice, string specialization) : base(taxNumber, firstName, lastName, birthDate)
        {
            YearOfStartPractice = yearsPractice;
            Specialization = specialization;
            DoctorNumber = peopleCounter;
        }

        public override void Input()
        {
            Console.Write("\nPlease enter Doctor{0} Tax Number.\nDoctor{0} Tax Number = ", DoctorNumber);
            TaxNumber = Int32.Parse(Console.ReadLine());
            Console.Write("\nPlease enter Doctor{0} first name.\nDoctor{0} First Name = ", DoctorNumber);
            FirstName = Console.ReadLine();
            Console.Write("\nPlease enter Doctor{0} last name.\nDoctor{0} Last Name = ", DoctorNumber);
            LastName = Console.ReadLine();
            Console.Write("\nPlease enter Doctor{0} birthday date (year, month, day).\nDoctor{0} birthday Year = ", DoctorNumber);
            int birthYear = Int32.Parse(Console.ReadLine());
            Console.Write("Doctor{0} birthday Month = ", DoctorNumber);
            int birthMonth = Int32.Parse(Console.ReadLine());
            Console.Write("Doctor{0} birthday Day = ", DoctorNumber);
            int birthDay = Int32.Parse(Console.ReadLine());
            BirthDate = new DateTime(birthYear, birthMonth, birthDay);
            Console.Write("\nPlease enter Doctor{0} number of years from starting practice.\nDoctor{0} YearOfStartPractice = ", DoctorNumber);
            YearOfStartPractice = Int32.Parse(Console.ReadLine());
            Console.Write("\nPlease enter Doctor{0} specialization.\nDoctor{0} Specialization = ", DoctorNumber);
            Specialization = Console.ReadLine();

        }

        public override string ToString()
        {
            return ("Tax: " + TaxNumber + "|\tFirstName: '" + FirstName +
                "'|\tLastName: '" + LastName + "'|\tBirthday: " +
                BirthDate.Day + "/" + BirthDate.Month + "/" + BirthDate.Year +
                "|\tAge: " + GetAge() + "\nYearOfStartPractice: " + YearOfStartPractice +
                "|\tSpecialization: '" + Specialization + "'.");
        }

        public override string Output()
        {
            return "\nDoctor" + DoctorNumber + ":\n" + ToString() +
                "\n. . . . . . . . . . . . . . . . . . . . . . . . " +
                ". . . . . . . . . . . . . . . . . . . . . . . . . . .";
        }
    }
}

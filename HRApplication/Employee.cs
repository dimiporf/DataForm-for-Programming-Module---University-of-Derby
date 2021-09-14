using System;
using System.Collections.Generic;
using System.Text;

namespace HRApplication
{
    public class Employee : IComparable<Employee>
    {
        
        public Employee()
        {
        }

        public Employee(string savedData) {
            string[] data = savedData.Split('|');
            LastName = data[0];
            FirstName = data[1];
            Address = data[2];
            PostCode = data[3];
            PhoneNumber = data[4];
            DateOfBirth = new DateTime (int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));
        }
        
        public Employee(string lastName,
                        string firstName,
                        string address,
                        string postCode,
                        string phoneNumber,
                        DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }                       
        
        public string FirstName { get; set; }      

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public virtual decimal Salary { get; set; }
        public virtual decimal OvertimePay { get; set; }

        public virtual decimal HourlyPay { get; set; }

        public string PhoneNumber { get; set; }
        //avoid setting property to integer, providing the ability to insert characters like "+" and " " (space) like some examples

        public DateTime DateOfBirth { get; set; }

        public int CompareTo(Employee obj)
        {
            return LastName.CompareTo(obj.LastName);
        }

        public virtual string SavedData
        {
            get {
                return LastName + "|" +
                  FirstName + "|" +
                  Address + "|" +
                  PostCode + "|" +
                  PhoneNumber + "|" +
                  DateOfBirth.Year + "|" +
                  DateOfBirth.Month + "|" +
                  DateOfBirth.Day + "|";
                
                   }
        }

        public bool isSalaried()
        {
            if (SavedData[0] == 'S')
                return true;
            else return false;
        }

        public bool isHourly()
        {
            if (SavedData[0] == 'H')
                return true;
            else return false;
        }

        
    }
}

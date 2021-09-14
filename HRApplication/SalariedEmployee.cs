using System;
using System.Collections.Generic;
using System.Text;

namespace HRApplication
{
    public class SalariedEmployee : Employee
    {

        public SalariedEmployee() { }
        public SalariedEmployee(string savedData)
        {
            string[] data = savedData.Split('|');
            LastName = data[1];
            FirstName = data[2];
            Address = data[3];
            PostCode = data[4];
            PhoneNumber = data[5];
            DateOfBirth = new DateTime(int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]));
            Salary = decimal.Parse(data[9]);

        }
        
        public SalariedEmployee(string lastName,
                        string firstName,
                        string address,
                        string postCode,
                        string phoneNumber,
                        DateTime dateOfBirth,decimal salary) : base (firstName, lastName, address, postCode, phoneNumber, dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }
        
        public override decimal Salary { get; set; }

        public override string SavedData
        {
            get
            {
                return "S"
                   +"|"+
                  base.SavedData+
                  Salary;

            }
        }

    }
}

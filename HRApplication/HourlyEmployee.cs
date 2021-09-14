using System;
using System.Collections.Generic;
using System.Text;

namespace HRApplication
{
    public class HourlyEmployee : Employee
    {
        public HourlyEmployee() { }

        public HourlyEmployee(string savedData)
        {
            string[] data = savedData.Split('|');
            LastName = data[1];
            FirstName = data[2];
            Address = data[3];
            PostCode = data[4];
            PhoneNumber = data[5];
            DateOfBirth = new DateTime(int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]));
            HourlyPay = decimal.Parse(data[9]);
            OvertimePay = decimal.Parse(data[10]);
        }
        
        public HourlyEmployee(string lastName,string firstName,
                              string address,
                              string postCode,
                              string phoneNumber,
                              DateTime dateOfBirth,
                              decimal hourlyPay,
                              decimal overtimePay) :base (firstName, lastName, address, postCode,phoneNumber, dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            PostCode = postCode;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;

            HourlyPay = hourlyPay;
            OvertimePay = overtimePay;
        }

        public override decimal HourlyPay { get; set; }

        public override decimal OvertimePay { get; set; }


        public override string SavedData
        {
            get
            {
                return "H" +"|"+
                  base.SavedData+
                  HourlyPay + "|"+
                  OvertimePay;

            }
        }
    }
}

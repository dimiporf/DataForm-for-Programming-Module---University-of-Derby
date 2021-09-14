using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApplication
{
    public class EmployeeDatabase
    {
        public static Employee CreateEntry(string streamLineRead)
        {
            switch (streamLineRead[0])
            {
                case 'H': return new HourlyEmployee(streamLineRead);
                case 'S': return new SalariedEmployee(streamLineRead);
                default: return null;
            }

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HRApplication
{
    public class Employees : List<Employee>
    {
        public Employees()
        {
        }

        public bool Load(string filename) {
            bool status = false;

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filename);
                string streamLineRead;
                streamLineRead = streamReader.ReadLine();
                while (streamLineRead != null)
                {

                    Employee employeeEntry = EmployeeDatabase.CreateEntry(streamLineRead);
                    Console.WriteLine(employeeEntry);
                    if (employeeEntry != null)
                        Add(employeeEntry);
                    streamLineRead = streamReader.ReadLine();

                }
                status = true;
            }
            catch
            {

            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }

            return status;
        }

        public bool Save(string filename)
        {
            bool status = false;

            StreamWriter streamWrite = null;
            try
            {
                streamWrite = new StreamWriter(filename, false);
                foreach (Employee entry in this)
                    streamWrite.WriteLine(entry.SavedData);
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Saved failed with error", e.Message);
            }
            finally
            {
                if (streamWrite != null)
                    streamWrite.Close();
            }

            return status;
        }

       
    }
}

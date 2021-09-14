using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApplication
{
    public partial class EmployeeForm : Form
    {
        Employee employee;
        


        public EmployeeForm()
        {
            InitializeComponent();
            

        }

        public Employee Employee
        {

            get { return employee; }
            set { employee = value; }

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if (employee.GetType() == typeof(SalariedEmployee))
            {
                this.Text = "Salaried Employee Form";
                hourlyPayTb.Visible = false;
                hourlyLb.Visible = false;
                overtimeLb.Visible = false;
                overtimePayTb.Visible = false;                

                firstNameTb.Text = employee.FirstName;
                lastNameTb.Text = employee.LastName;
                addressTb.Text = employee.Address;
                postcodeTb.Text = employee.PostCode;
                phoneNumberTb.Text = employee.PhoneNumber;
                try
                {
                    dateOfBirthPicker.Value = employee.DateOfBirth;
                }
                catch { }

                if (employee.Salary !=0)
                annualSalaryTb.Text = employee.Salary.ToString();
                

                
            }
            else if (employee.GetType() == typeof(HourlyEmployee))
            {
                this.Text = "Hourly Employee Form";

                annualSalaryTb.Visible = false;
                annualSalaryLb.Visible = false;
                

                firstNameTb.Text = employee.FirstName;
                lastNameTb.Text = employee.LastName;
                addressTb.Text = employee.Address;
                postcodeTb.Text = employee.PostCode;
                phoneNumberTb.Text = employee.PhoneNumber;
                try
                {
                    dateOfBirthPicker.Value = employee.DateOfBirth;
                }
                catch { }
                
                if (employee.HourlyPay != 0)
                {
                    hourlyPayTb.Text = employee.HourlyPay.ToString();

                    overtimePayTb.Text = employee.OvertimePay.ToString();
                }
            }
        
    

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (employee != null)
            {
                employee.FirstName = firstNameTb.Text;
                employee.LastName = lastNameTb.Text;
                employee.Address = addressTb.Text;
                employee.PostCode = postcodeTb.Text;
                employee.PhoneNumber = phoneNumberTb.Text;
                employee.DateOfBirth = dateOfBirthPicker.Value;
                if (employee.isSalaried())
                {
                    try
                    {
                        employee.Salary = errorCheck(annualSalaryTb.Text, "Salary");

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Application encountered an error!", error.ToString());
                    }
                }

                else if (employee.isHourly())
                {
                    try 
                        {
                        employee.OvertimePay = errorCheck(overtimePayTb.Text, "Overtime Pay");
                        employee.HourlyPay = errorCheck(hourlyPayTb.Text, "Hourly Pay");

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Application encountered an error!", error.ToString());
                    }                
            }

                if (employee.FirstName != null && (employee.HourlyPay != 0 || employee.Salary != 0))
                {
                    
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Not all the information required was provided. Please try again!!");
                    DialogResult = DialogResult.Cancel;
                }

                decimal errorCheck (string property, string errorMsg) 
                {
                    decimal decimalResult;

                    bool tempo = decimal.TryParse(property, out decimalResult);

                    if (!tempo)
                    {
                        WarningMessage(errorMsg);
                        return 0;
                    }
                    return decimalResult;
                }

                void WarningMessage(string input) 
                {
                    MessageBox.Show("Please type a valid decimal input!!", input+" Wrong Input");
                }
            }

            
            }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
    }
}

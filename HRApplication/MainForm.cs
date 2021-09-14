using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HRApplication
{
    public partial class MainForm : Form
    {
        // The file used to store employee details
        string employeesFile = "employees.txt"; 



        // The collection used to hold the employee data
        Employees employees;


        public MainForm()
        {
            InitializeComponent();
        }
                

        private void MainForm_Load(object sender, EventArgs e)
        {
            employees = new Employees();
            if (!employees.Load(employeesFile))
            {
                MessageBox.Show("Unable to load employees file");
            }
            else
            {
                PopulateListBox();
            }
        }
        
        private void PopulateListBox()
        {
           listBoxEmployees.Items.Clear();
                        
            employees.Sort();
            foreach (Employee employee in employees)
            {
                listBoxEmployees.Items.Add(employee.LastName + ", " + employee.FirstName);
            }
            listBoxEmployees.SelectedIndex = 0;
        }

        private void CreateForm(Employee currentEmployee)
        {
            EmployeeForm dataform = new EmployeeForm();
            dataform.Employee = currentEmployee;

            DialogResult result = dataform.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!employees.Contains(currentEmployee))
                {
                    employees.Add(currentEmployee);
                }
                bool savedSuccess = employees.Save("employees.txt");

                PopulateListBox();

            }
            dataform.Dispose();

        }              

        private void listBoxEmployees_DoubleClick(object sender, EventArgs e)
        {
            CreateForm(employees[listBoxEmployees.SelectedIndex]);
        }
        
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //similar as double click event above, just demonstrating another way to do it

            int selectedIndex = listBoxEmployees.SelectedIndex;
            CreateForm(employees[selectedIndex]);
        }

        private void buttonNewSalaried_Click(object sender, EventArgs e)
        {
            
            CreateForm(new SalariedEmployee());
        }

        private void buttonNewHourly_Click(object sender, EventArgs e)
        {
            CreateForm(new HourlyEmployee());
        }
    }
}
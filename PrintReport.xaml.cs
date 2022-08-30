using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialCalculator
{
    /// <summary>
    /// Interaction logic for PrintReport.xaml
    /// </summary>
    /// 


    public partial class PrintReport : Window
    {

        // Creating the delegate
        public delegate string expenseExceedsIncomeCheck(double gross, double total);

        //// Creating the event
        public event expenseExceedsIncomeCheck compareIncomeExpense;

        //// Creating the method
        public string checkIncomeExpenseMethod(double gross, double total)
        {
            string outcome = "";
            const double percentage = 0.75;
            // Checking to see if the expenses exceed 75% of the income
            if (total > (percentage * gross))
            {
                outcome = "\nYour monthly expenses exceed 75% of your monthly income!";
            }
            return outcome;
        }
        public PrintReport(personalDetails details, List<Expense> expenseList)
        {
            InitializeComponent();
            string idNumber;
            StringBuilder report = new StringBuilder();
            report.AppendLine("***********************************");
            report.AppendLine("*******FINANCIAL REPORT*******");
            report.AppendLine("***********************************");

            // Displaying the users personal details
            report.AppendLine("\nPERSONAL DETAILS:");
            report.AppendLine("-> Full Name: " + details.FullName);
            report.AppendLine("-> ID Number: " + details.IdNumber);
            idNumber = details.IdNumber + ".txt";
            report.AppendLine("-> Cell Number: " + details.CellNumber);
            double grossIncome = details.GrossIncome;
            report.AppendLine("-> Gross Income: R " + grossIncome);
            report.AppendLine("\nMonthly Tax Deduction: R " + details.TaxDeduction);

            // Sorting the users monthly expenses in descendiing order
            var orderExpenses = new List<orderExpense>();

            // Adding the objects to the list to sort
            foreach (var expense in expenseList)
            {
                if (expense is generalExpense)
                {
                    var generalExpense = (generalExpense)expense;
                    orderExpenses.Add(new orderExpense
                    {
                        ExpenseDescription = "Groceries Expense: R ",
                        ExpenseAmount = generalExpense.Groceries
                    });
                    orderExpenses.Add(new orderExpense
                    {
                        ExpenseDescription = "Water and Lights: R ",
                        ExpenseAmount = generalExpense.WaterLights
                    });
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Travel Expenses: R ", ExpenseAmount = generalExpense.Travel });
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Cell/Tele Expense: R ", ExpenseAmount = generalExpense.CellTele });
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Other Expenses: R ", ExpenseAmount = generalExpense.Other });
                }
                else if (expense is rentingExpense)
                {
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Renting Amount: R ", ExpenseAmount = ((rentingExpense)expense).RentalAmount });
                }
                else if (expense is BuyingExpense)
                {
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Housing Installment: R ", ExpenseAmount = ((BuyingExpense)expense).getTotalExpense() });
                }
                else if (expense is vehicleExpense)
                {
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Vehicle Installment: R ", ExpenseAmount = ((vehicleExpense)expense).getTotalExpense() });
                }
                else if (expense is savings)
                {
                    orderExpenses.Add(new orderExpense { ExpenseDescription = "Savings Contribution R ", ExpenseAmount = ((savings)expense).getTotalExpense() });
                }
            }

            // Sorting the values in the list into descending order using LINQ
            var sorted = orderExpenses.OrderByDescending(e => e.ExpenseAmount).ToList();

            report.AppendLine("\nBREAKDOWN OF MONTHLY EXPENSES (desc):");
            foreach (orderExpense output in sorted)
            {
                report.AppendLine("-> " + output.ExpenseDescription + output.ExpenseAmount);
            }

            // Variable to store the total expenses
            double totalExpense = 0;

            // Checking whether the monthly housing installment is greater than 1/3 of the income
            foreach (orderExpense output in sorted)
            {
                if (output.ExpenseDescription.Equals("Housing Installment: R "))
                {
                    if (output.ExpenseAmount > (grossIncome) / 3)
                    {
                        report.AppendLine("\nYour housing installment is greater than 1/3");
                        report.AppendLine("of your income. Please Note: The chances of your");
                        report.AppendLine("home loan being approved is unlikely!");
                    }
                    else
                    {
                        report.AppendLine("Home Loan approval is likely to be successful!");
                    }
                }
                totalExpense += output.ExpenseAmount;
            }

            // Subscribing to the event
            compareIncomeExpense += checkIncomeExpenseMethod;
            report.AppendLine("\nTOTAL MONTHLY EXPENDITURE: R " + totalExpense);

            report.AppendLine(compareIncomeExpense(grossIncome, totalExpense));

            report.AppendLine("Funds remaining: R " + (grossIncome - details.TaxDeduction - totalExpense));
            rTxbReport.Content = report.ToString();

            
        }

        private void btnPrintReport_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}

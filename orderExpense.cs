using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    class orderExpense
    {
        // Private variable that define the class
        private string expenseDescription;
        private double expenseAmount;

        // Getter and setter methods to store and retrieve values
        public string ExpenseDescription { get => expenseDescription; set => expenseDescription = value; }
        public double ExpenseAmount { get => expenseAmount; set => expenseAmount = value; }
    }
}

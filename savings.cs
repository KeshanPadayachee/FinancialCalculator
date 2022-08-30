using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    public class savings : Expense
    {
        // Creating the private variables
        private double total;
        private double interest;
        private int years;
        private string description;

        // Constructor
        public savings(double total, double interest, int years,
            string description)
        {
            this.total = total;
            this.interest = interest;
            this.years = years;
            this.description = description;
        }

        // Getter methods to access the values
        public double Total { get => total;}
        public double Interest { get => interest;}
        public int Years { get => years;}
        public string Description { get => description;}


        public double calculateMonthlySavingsExpense()
        {
            // A = P ( 1+ i)^n
            double monthly = this.total / Math.Pow((1+(this.interest/100)),this.years);
            return monthly;
        }
        public override double getTotalExpense()
        {
            return calculateMonthlySavingsExpense();
        }
    }
}

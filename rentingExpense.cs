using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    public class rentingExpense : Expense
    {
        // Private variable that define the class
        private double rentalAmount;

        // Constructor
        public rentingExpense(double rentalAmount)
        {
            this.rentalAmount = rentalAmount;
        }

        // Getter method to access the value stored in the class
        public double RentalAmount { get => rentalAmount;}

        public override double getTotalExpense()
        {
            return this.rentalAmount;
        }
    }
}

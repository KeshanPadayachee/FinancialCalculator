using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    public class BuyingExpense : Expense
    {
        // Private variable that define the class
        private double purchasePrice;
        private double depositAmount;
        private double interestRate;
        private double numberMonths;

        // Constructor
        public BuyingExpense(double purchasePrice, double depositAmount,
            double interestRate, int numberMonths)
        {
            this.purchasePrice = purchasePrice;
            this.depositAmount = depositAmount;
            this.interestRate = interestRate;
            this.numberMonths = numberMonths;
        }

        // Getter methods to access the values stored in the class
        public double PurchasePrice { get => purchasePrice;}
        public double DepositAmount { get => depositAmount;}
        public double InterestRate { get => interestRate;}
        public double NumberMonths { get => numberMonths;}

        // Method to calculate the monthly installment
        public double calculateMonthlyInstallment()
        {
            double monthlyInstallment = 0;
            // Using formula A = P ( 1 + i*n )
            // P
            double P = this.purchasePrice - this.depositAmount;

            // i*n
            double iTimesN = (this.interestRate / 100) * (this.numberMonths / 12);

            // A
            double A = P * (1 + iTimesN);

            // A divided by number of months
            monthlyInstallment = A / this.numberMonths;
            return Math.Round(monthlyInstallment,2);
        }

        // Method to access the value of the monthly installment
        public override double getTotalExpense()
        {
            return calculateMonthlyInstallment();
        }
    }
}

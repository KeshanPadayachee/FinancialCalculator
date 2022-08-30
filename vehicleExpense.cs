using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    public class vehicleExpense : Expense
    {
        // Private variables that define the class
        private string vehicleMake;
        private string vehicleModel;
        private double purchasePrice;
        private double depositAmount;
        private double interestRate;
        private double insurancePremium;
        private const int numberYears = 5;

        // Constructor
        public vehicleExpense(string vehicleMake, string vehicleModel, double purchasePrice,
            double depositAmount, double interestRate, double insurancePremium)
        {
            this.vehicleMake = vehicleMake;
            this.vehicleModel = vehicleModel;
            this.purchasePrice = purchasePrice;
            this.depositAmount = depositAmount;
            this.interestRate = interestRate;
            this.insurancePremium = insurancePremium;
        }

        // Getter methods to access the values stroed in the class
        public string VehicleMake { get => vehicleMake; set => vehicleMake = value; }
        public string VehicleModel { get => vehicleModel; set => vehicleModel = value; }
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double DepositAmount { get => depositAmount; set => depositAmount = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public double InsurancePremium { get => insurancePremium; set => insurancePremium = value; }

        // Method to calculate the monthly installment
        public double calculateMonthlyInstallment()
        {
            double monthlyInstallment = 0;
            // Using A = P ( 1 + i*n )
            // P
            double P = this.purchasePrice - this.depositAmount;

            // i*n
            double iTimesN = (this.interestRate / 100) * numberYears;

            // A
            double A = P * (1 + iTimesN);
            monthlyInstallment = A / (numberYears * 12);
            return monthlyInstallment+this.insurancePremium;
        }

        // Method to return the monthly installment
        public override double getTotalExpense()
        {
            return calculateMonthlyInstallment();
        }
        
    }
}

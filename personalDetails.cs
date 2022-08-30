using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    public class personalDetails
    {
        // Private variables that define the class
        private string fullName;
        private string idNumber;
        private string cellNumber;
        private string emailAddress;
        private double grossIncome;
        private double taxDeduction;

        // Constructor
        public personalDetails(string fullName, string idNumber, string cellNumber,
            string emailAddress, double grossIncome, double taxDeduction)
        {
            this.fullName = fullName;
            this.idNumber = idNumber;
            this.cellNumber = cellNumber;
            this.emailAddress = emailAddress;
            this.grossIncome = grossIncome;
            this.taxDeduction = taxDeduction;
        }

        // Getter methods to access the values stored in the class
        public string FullName { get => fullName; }
        public string IdNumber { get => idNumber; }
        public string CellNumber { get => cellNumber; }
        public string EmailAddress { get => emailAddress; }
        public double GrossIncome { get => grossIncome; }
        public double TaxDeduction { get => taxDeduction; }
    }
}

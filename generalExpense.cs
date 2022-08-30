using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialCalculator
{
    public class generalExpense : Expense
    {
        // Private variables that define the class
        private double groceries;
        private double waterLights;
        private double travel;
        private double cellTele;
        private double other;

        // Constructor
        public generalExpense(double groceries, double waterLights, double travel,
            double cellTele, double other)
        {
            this.groceries = groceries;
            this.waterLights = waterLights;
            this.travel = travel;
            this.cellTele = cellTele;
            this.other = other;
        }

        // Getter methods to access the values stored in the class
        public double Groceries { get => groceries;}
        public double WaterLights { get => waterLights;}
        public double Travel { get => travel;}
        public double CellTele { get => cellTele;}
        public double Other { get => other;}

        // Method to return the total value of the general expenses
        public override double getTotalExpense()
        {
            return (this.groceries + this.waterLights + this.travel + 
                this.cellTele + this.other);
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Hiding the grids until the user selects and option(buying/selling)
            gridRenting.Visibility = Visibility.Hidden;
            gridBuying.Visibility = Visibility.Hidden;
            // Hiding the vehicle buying option
            gridVehicle.Visibility = Visibility.Hidden;
            // Hiding the savings menu
            gridSavings.Visibility = Visibility.Hidden;

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (txbIDNumber.Text.Length != 13 || txbCellNumber.Text.Length != 10)
            {
                MessageBox.Show("Please check your ID Number and/or Cell Number and try again!");
            }
            else
            {
                // Creating a new instance of the personal details class and passing the values
                personalDetails personaldetails = new personalDetails(txbFullName.Text,
                    txbIDNumber.Text,
                    txbCellNumber.Text,
                    txbEmailAddress.Text,
                    Convert.ToDouble(txbGrossIncome.Text),
                    Convert.ToDouble(txbTaxDeduction.Text));

                // Creating a list of type expense to store all the expense objects\
                List<Expense> lstExpenses = new List<Expense>();

                // Instantiating objects of the child classes
                generalExpense genExpense;
                vehicleExpense vehicle;
                Expense housingExpense;

                // Creating an instance of the general expense class
                genExpense = new generalExpense(Convert.ToDouble(txbGroceries.Text),
                    Convert.ToDouble(txbWaterLights.Text),
                    Convert.ToDouble(txbTravel.Text),
                    Convert.ToDouble(txbCellTele.Text),
                    Convert.ToDouble(txbOther.Text));

                // Adding the instance to the list
                lstExpenses.Add(genExpense);

                // Checking to see whether the user will be buying or renting
                if (rdBtnBuying.IsChecked == true)
                {
                    if (Convert.ToInt32(txbHRepayPeriod.Text) >= 240 && Convert.ToInt32(txbHRepayPeriod.Text) <= 360)
                    {
                        housingExpense = new BuyingExpense(Convert.ToDouble(txbHPurchasePrice.Text),
                                                Convert.ToDouble(txbHDepositAmount.Text),
                                                Convert.ToDouble(txbHInterestRate.Text),
                                                Convert.ToInt32(txbHRepayPeriod.Text));

                        // Adding the instance to the list
                        lstExpenses.Add(housingExpense);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a value between 240 and 360 for your housing repayment period.");
                        return;
                    }

                }
                else if (rdBtnRenting.IsChecked == true)
                {
                    housingExpense = new rentingExpense(Convert.ToDouble(txbRentAmount.Text));

                    // Adding the instance to the list
                    lstExpenses.Add(housingExpense);
                }

                // Checking to see if the user will be buying a car
                if (rdBtnBuyingVehicle.IsChecked == true)
                {
                    vehicle = new vehicleExpense(txbVMake.Text,
                        txbVModel.Text,
                        Convert.ToDouble(txbVPurchasePrice.Text),
                        Convert.ToDouble(txbVDepositAmount.Text),
                        Convert.ToDouble(txbVInterestRate.Text),
                        Convert.ToDouble(txbVInsurancePremium.Text));

                    // Adding the instance to the list
                    lstExpenses.Add(vehicle);
                }
                if (rdBtnYes.IsChecked == true)
                {
                    savings save = new savings(Convert.ToDouble(txbTotalSaving.Text),
                        Convert.ToDouble(txbPercentage.Text),
                        Convert.ToInt32(txbYears.Text),
                        txbDescription.Text);
                    lstExpenses.Add(save);
                }
                PrintReport report = new PrintReport(personaldetails, lstExpenses);
                report.ShowDialog();
            }

            

            
            
        }

        private void rdBtnBuying_Checked(object sender, RoutedEventArgs e)
        {
            gridBuying.Margin = new Thickness(389, 212, 509, 92);
            gridBuying.Visibility = Visibility.Visible;
            gridRenting.Visibility = Visibility.Hidden;
        }

        private void rdBtnRenting_Checked(object sender, RoutedEventArgs e)
        {
            gridRenting.Margin = new Thickness(389, 212, 509, 291);
            gridRenting.Visibility = Visibility.Visible;
            gridBuying.Visibility = Visibility.Hidden;
        }

        private void rdBtnBuyingVehicle_Checked(object sender, RoutedEventArgs e)
        {
            if (rdBtnBuyingVehicle.IsChecked == true)
            {
                gridVehicle.Visibility = Visibility.Visible;
            }
            else
            {
                gridVehicle.Visibility = Visibility.Hidden;
            }
            
        }

        private void rdBtnYes_Checked(object sender, RoutedEventArgs e)
        {
            // Showing the savings menu
            gridSavings.Visibility = Visibility.Visible;
        }

        private void rdBtnNo_Checked(object sender, RoutedEventArgs e)
        {
            // Hiding the savings menu
            gridSavings.Visibility = Visibility.Hidden;
        }
    }
}

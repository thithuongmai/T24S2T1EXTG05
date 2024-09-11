using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		// Method to handle the calculation when the "Calculate" button is clicked
		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Parsing input values
				double principal = double.Parse(PrincipalTextBox.Text);
				int years = int.Parse(YearsTextBox.Text);
				int months = int.Parse(MonthsTextBox.Text);
				double yearlyInterestRate = double.Parse(YearlyInterestRateTextBox.Text) / 100; // Convert to percentage

				// Calculating the monthly interest rate
				double monthlyInterestRate = yearlyInterestRate / 12;

				// Update the Monthly Interest Rate field
				MonthlyInterestRateTextBox.Text = (monthlyInterestRate * 100).ToString("F4");

				// Calculating the number of months (n = years * 12 + additional months)
				int totalMonths = (years * 12) + months;

				// Formula: M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1 ]
				double repayment = CalculateMonthlyRepayment(principal, monthlyInterestRate, totalMonths);

				// Display the calculated monthly repayment
				MonthlyRepaymentTextBox.Text = repayment.ToString("C2"); // Display as currency format
			}
			catch (FormatException)
			{
				// Handle invalid input
				MonthlyRepaymentTextBox.Text = "Invalid input. Please check the values.";
			}
		}

		// Method to calculate the monthly repayment using the provided formula
		private double CalculateMonthlyRepayment(double principal, double monthlyInterestRate, int totalMonths)
		{
			// Formula: M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1 ]
			double factor = Math.Pow(1 + monthlyInterestRate, totalMonths);
			double repayment = principal * (monthlyInterestRate * factor) / (factor - 1);

			return repayment;
		}

		// Method to handle Exit button click (close the app or navigate away)
		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit(); // Exit the application
		}
	}
}

using System;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
	public sealed partial class MainMenu : Page
	{
		// default var
		public static MainMenu mainmenu { get; set; }

		// default functions
		public MainMenu()
		{
			InitializeComponent();

			mainmenu = this;

		}

		// page functions
		private void pageLoaded(object sender, RoutedEventArgs e)
		{
			// window minimum size
			ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(256, 384));

			// enable title bar full customiztion
			CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
			// title bar customization
			ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

			titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
			titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;
			titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.White;
		}

		private void MathsCalculator_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to the Maths
			Frame.Navigate(typeof(MainPage));
		}
		private async void MortgageCalculator_Click(object sender, RoutedEventArgs e)
		{
			var newView = CoreApplication.CreateNewView();

			// Run the code to display the MortgageCalculator page in the new view
			await newView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
			{
				// Create a new Frame and navigate to the MortgageCalculator page
				var newFrame = new Frame();
				newFrame.Navigate(typeof(MortgageCalculator));

				// Set the new frame's content as the window content
				Window.Current.Content = newFrame;
				Window.Current.Activate();

				// Try to show the window and move it to the foreground
				var newAppView = ApplicationView.GetForCurrentView();
				await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id);
			});
		}
		private void CurrencyConverter_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to the Currency Converter page
			Frame.Navigate(typeof(currencyConverter));
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}
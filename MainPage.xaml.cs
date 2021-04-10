using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace HelloMaui
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage, IPage
	{
		Random rnd = new Random();

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnSwapMainColorClicked(object sender, EventArgs e)
		{
			chart.MainColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
		}

		private void OnSwapCrosshairObjectClicked(object sender, EventArgs e)
		{
			chart.Crosshair.CrosshairMoved -= OnCroshairMoved;

			chart.Crosshair = new CrosshairSettings
			{
				TextColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))
			};

			chart.Crosshair.CrosshairMoved += OnCroshairMoved;
		}

		private void OnCroshairMoved(object sender, EventArgs e)
		{
			movedLabel.Text = $"Corosshair \"moved\" at {DateTime.Now}";
		}

		private void OnSwapCrosshairColorClicked(object sender, EventArgs e)
		{
			chart.Crosshair.TextColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
		}

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}
}

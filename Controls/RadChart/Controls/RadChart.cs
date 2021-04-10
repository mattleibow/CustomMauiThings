using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace HelloMaui
{
	public class RadChart : View, IRadChart
	{
		public readonly BindableProperty MainColorProperty = BindableProperty.Create(
			nameof(MainColor), typeof(Color), typeof(RadChart), Color.Red);

		public readonly BindableProperty CrosshairProperty = BindableProperty.Create(
			nameof(Crosshair), typeof(CrosshairSettings), typeof(RadChart), defaultValueCreator: _ => new CrosshairSettings());

		public Color MainColor
		{
			get => (Color)GetValue(MainColorProperty);
			set => SetValue(MainColorProperty, value);
		}

		public CrosshairSettings Crosshair
		{
			get => (CrosshairSettings)GetValue(CrosshairProperty);
			set => SetValue(CrosshairProperty, value);
		}

		ICrosshairSettings IRadChart.Crosshair => Crosshair;
	}
}

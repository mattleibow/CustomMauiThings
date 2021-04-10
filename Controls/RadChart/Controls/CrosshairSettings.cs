using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace HelloMaui
{
	public class CrosshairSettings : BindableObject, ICrosshairSettings
	{
		public readonly BindableProperty TextColorProperty = BindableProperty.Create(
			nameof(TextColor), typeof(Color), typeof(CrosshairSettings), Color.Black);

		public readonly BindableProperty ValueFormatProperty = BindableProperty.Create(
			nameof(ValueFormat), typeof(string), typeof(CrosshairSettings), (string)null);

		public Color TextColor
		{
			get => (Color)GetValue(TextColorProperty);
			set => SetValue(TextColorProperty, value);
		}

		public string ValueFormat
		{
			get => (string)GetValue(ValueFormatProperty);
			set => SetValue(ValueFormatProperty, value);
		}

		public event EventHandler CrosshairMoved;

		void ICrosshairSettings.OnCrosshairMoved()
		{
			CrosshairMoved?.Invoke(this, EventArgs.Empty);
		}
	}
}

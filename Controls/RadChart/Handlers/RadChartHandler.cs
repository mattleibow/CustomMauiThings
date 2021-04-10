using AndroidX.AppCompat.Widget;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.ComponentModel;

namespace HelloMaui
{
	public class RadChartHandler : ViewHandler<IRadChart, AppCompatButton>
	{
		static readonly PropertyMapper<IRadChart, RadChartHandler> RadChartMapper =
			new PropertyMapper<IRadChart, RadChartHandler>(ViewHandler.ViewMapper)
			{
				[nameof(IRadChart.MainColor)] = MapMainColor,
				[nameof(IRadChart.Crosshair)] = MapCrosshair,
			};

		ICrosshairSettings currentSettings;

		public RadChartHandler() : base(RadChartMapper)
		{
		}

		public RadChartHandler(PropertyMapper mapper = null) : base(mapper ?? RadChartMapper)
		{
		}

		protected override void ConnectHandler(AppCompatButton nativeView)
		{
			base.ConnectHandler(nativeView);

			AttachEvents();
		}

		protected override void DisconnectHandler(AppCompatButton nativeView)
		{
			DetachEvents();

			base.DisconnectHandler(nativeView);
		}

		protected override AppCompatButton CreateNativeView() => new AppCompatButton(Context) { Text = "The RAD Chart" };

		static void MapMainColor(RadChartHandler handler, IRadChart view)
		{
			handler.NativeView?.SetBackgroundColor(view.MainColor.ToNative());
		}

		static void MapCrosshair(RadChartHandler handler, IRadChart view)
		{
			handler.DetachEvents();

			MapCrosshairSettings(handler, view.Crosshair);

			handler.AttachEvents();
		}

		static void MapCrosshairSettings(RadChartHandler handler, ICrosshairSettings settings)
		{
			handler.NativeView?.SetTextColor(settings.TextColor.ToNative());
		}

		private void AttachEvents()
		{
			if (VirtualView.Crosshair is ICrosshairSettings settings)
			{
				currentSettings = settings;
				currentSettings.PropertyChanged += OnCroshairPropertyChanged;
			}
		}

		private void DetachEvents()
		{
			if (currentSettings is ICrosshairSettings settings)
			{
				currentSettings.PropertyChanged -= OnCroshairPropertyChanged;
			}
		}

		private void OnCroshairPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			MapCrosshairSettings(this, currentSettings);
		}
	}
}

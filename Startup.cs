using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Hosting;

namespace HelloMaui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseFormsCompatibility()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("ionicons.ttf", "IonIcons");
				})
				.ConfigureMauiHandlers(handlers =>
				{
					handlers.AddHandler<RadChart, RadChartHandler>();
				});
		}
	}
}
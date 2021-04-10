using Microsoft.Maui;

namespace HelloMaui
{
	public interface IRadChart : IView
	{
		Color MainColor { get; }

		ICrosshairSettings Crosshair { get; }
	}
}

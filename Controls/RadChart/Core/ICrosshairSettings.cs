using System.ComponentModel;
using Microsoft.Maui;

namespace HelloMaui
{
	public interface ICrosshairSettings : INotifyPropertyChanged
	{
		Color TextColor { get; }

		string ValueFormat { get; }

		void OnCrosshairMoved();
	}
}

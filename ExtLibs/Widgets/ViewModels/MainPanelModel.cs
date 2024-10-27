using System.Windows.Input;
using ReactiveUI;

namespace Widgets.ViewModels;

public class MainPanelModel : ViewModelBase
{
	// Avalonia handlers
	public ICommand OpenHelpPage => ReactiveCommand.Create(() =>
	{
		HelpButtonClickHandler();
	});

	// MainV2 handlers
	public delegate void ButtonHandler();
	public required ButtonHandler HelpButtonClickHandler;
}

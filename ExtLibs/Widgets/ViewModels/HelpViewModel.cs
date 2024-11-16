using System.Windows.Input;
using ReactiveUI;

namespace Widgets.ViewModels;

public class HelpViewModel : ViewModelBase
{
	private bool _ShowConsole;
	public bool ShowConsole
	{
		get => _ShowConsole;
		set
		{
			_ShowConsole = value;
			ShowConsoleCheckboxClickHandler(_ShowConsole);
		}
	}

	// Avalonia handlers
	public ICommand CheckUpdates => ReactiveCommand.Create(() =>
	{
		CheckUpdatesButtonClickHandler();
	});

	public ICommand CheckBetaUpdates => ReactiveCommand.Create(() =>
	{
		CheckBetaUpdatesButtonClickHandler();
	});

	public ICommand OpenChangeLog => ReactiveCommand.Create(() =>
	{
		ChangeLogClickHandler();
	});

	// MainV2 handlers
	public delegate void ButtonHandler();
	public delegate void CheckboxHandler(bool checkedValue);

	public required ButtonHandler CheckUpdatesButtonClickHandler;
	public required ButtonHandler CheckBetaUpdatesButtonClickHandler;
	public required ButtonHandler ChangeLogClickHandler;
	public required CheckboxHandler ShowConsoleCheckboxClickHandler;
}

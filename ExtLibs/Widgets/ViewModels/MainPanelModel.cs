using System.Windows.Input;
using ReactiveUI;

namespace Widgets.ViewModels;

public class MainPanelModel : ViewModelBase
{
	// Avalonia handlers
	public ICommand OpenDataPage => ReactiveCommand.Create(() =>
	{
		DataButtonClickHandler();
	});

	public ICommand OpenPlanPage => ReactiveCommand.Create(() =>
	{
		PlanButtonClickHandler();
	});

	public ICommand OpenSetupPage => ReactiveCommand.Create(() =>
	{
		SetupButtonClickHandler();
	});

	public ICommand OpenConfigPage => ReactiveCommand.Create(() =>
	{
		ConfigButtonClickHandler();
	});

	public ICommand OpenSimulationPage => ReactiveCommand.Create(() =>
	{
		SimulationButtonClickHandler();
	});

	public ICommand OpenHelpPage => ReactiveCommand.Create(() =>
	{
		HelpButtonClickHandler();
	});

	// MainV2 handlers
	public delegate void ButtonHandler();

	public required ButtonHandler DataButtonClickHandler;
	public required ButtonHandler PlanButtonClickHandler;
	public required ButtonHandler SetupButtonClickHandler;
	public required ButtonHandler ConfigButtonClickHandler;
	public required ButtonHandler SimulationButtonClickHandler;
	public required ButtonHandler HelpButtonClickHandler;

}

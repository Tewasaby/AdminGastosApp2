using AdminGastosApp.ViewModels;

namespace AdminGastosApp.Views;

public partial class AgregarGastoPage : ContentPage
{
	public AgregarGastoPage(AgregarGastoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; // VM asignado automáticamente
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
	}
}
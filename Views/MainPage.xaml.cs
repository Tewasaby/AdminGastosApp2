using AdminGastosApp.ViewModels;

namespace AdminGastosApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(GastosViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; // 🔹 Asignamos el ViewModel inyectado
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is GastosViewModel vm)
			await vm.LoadGastosCommand.ExecuteAsync(null);
	}
}
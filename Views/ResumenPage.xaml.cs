using AdminGastosApp.ViewModels;

namespace AdminGastosApp.Views;

public partial class ResumenPage : ContentPage
{
	// El ViewModel se inyecta automáticamente
	public ResumenPage(ResumenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; // Asignación del VM
	}
}
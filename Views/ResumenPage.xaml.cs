using AdminGastosApp.ViewModels;

namespace AdminGastosApp.Views;

public partial class ResumenPage : ContentPage
{
	// El ViewModel se inyecta autom�ticamente
	public ResumenPage(ResumenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel; // Asignaci�n del VM
	}
}
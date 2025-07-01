using AdminGastosApp.Services;
using AdminGastosApp.ViewModels;

namespace AdminGastosApp.Views;

public partial class AgregarCategoriaPage : ContentPage
{
	public AgregarCategoriaPage(DatabaseService dbService)
	{
		InitializeComponent();
		BindingContext = new AgregarCategoriaViewModel(dbService);
	}
}
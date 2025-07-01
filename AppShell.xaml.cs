using AdminGastosApp.Views;

namespace AdminGastosApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

			Routing.RegisterRoute(nameof(AgregarGastoPage), typeof(AgregarGastoPage));
			Routing.RegisterRoute(nameof(ResumenPage), typeof(ResumenPage));

			Routing.RegisterRoute(nameof(AgregarCategoriaPage), typeof(AgregarCategoriaPage));


		}
    }
}

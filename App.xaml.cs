using System.Globalization;

namespace AdminGastosApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

		public class NullToFalseConverter : IValueConverter
		{
			public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
				=> value != null;

			public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
				=> throw new NotImplementedException();
		}
	}
}
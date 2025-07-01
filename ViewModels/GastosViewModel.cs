using AdminGastosApp.Models;
using AdminGastosApp.Services;
using AdminGastosApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastosApp.ViewModels
{
	public partial class GastosViewModel : ObservableObject
	{
		private readonly DatabaseService _dbService;

		[ObservableProperty]
		private ObservableCollection<Gasto> gastos = new();

		// 🔹 Inyección de DatabaseService en el constructor
		public GastosViewModel(DatabaseService dbService)
		{
			_dbService = dbService;
			LoadGastosCommand.Execute(null); // Cargar datos al iniciar
		}

		// Comando para cargar gastos
		[RelayCommand]
		private async Task LoadGastos()
		{
			var lista = await _dbService.GetGastosPorMesAsync(DateTime.Now.Year, DateTime.Now.Month);
			Gastos.Clear();
			foreach (var item in lista)
				Gastos.Add(item);
		}

		// Comando para navegar a la página de agregar gasto
		[RelayCommand]
		private async Task AddGasto()
		{
			await Shell.Current.GoToAsync(nameof(AgregarGastoPage));
		}

	}
}

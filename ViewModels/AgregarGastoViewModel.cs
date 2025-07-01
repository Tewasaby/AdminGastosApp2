using AdminGastosApp.Models;
using AdminGastosApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastosApp.ViewModels
{
	public partial class AgregarGastoViewModel : ObservableObject
	{
		private readonly DatabaseService _dbService;

		[ObservableProperty]
		private string _descripcion;

		[ObservableProperty]
		private decimal _monto;

		[ObservableProperty]
		private DateTime _fecha = DateTime.Now;

		[ObservableProperty]
		private string _categoriaSeleccionada;

		[ObservableProperty]
		private List<string> _categorias = new();

		public AgregarGastoViewModel(DatabaseService dbService)
		{
			_dbService = dbService;
			_ = CargarCategoriasAsync(); // Carga al iniciar
		}

		private async Task CargarCategoriasAsync()
		{
			var categoriasDesdeBD = await _dbService.GetCategoriasAsync();
			Categorias = categoriasDesdeBD.Select(c => c.Nombre).ToList();

			// Establecer la categoría por defecto
			CategoriaSeleccionada = Categorias.FirstOrDefault();
		}


		[RelayCommand]
		private async Task GuardarGasto()
		{
			if (Monto <= 0)
			{
				await Shell.Current.DisplayAlert("Error", "El monto debe ser mayor a 0", "OK");
				return;
			}

			var nuevoGasto = new Gasto
			{
				Descripcion = Descripcion,
				Monto = Monto,
				Fecha = Fecha,
				Categoria = CategoriaSeleccionada
			};

			await _dbService.AddGastoAsync(nuevoGasto);
			await Shell.Current.GoToAsync(".."); // Regresar a la página anterior
		}
	}
}

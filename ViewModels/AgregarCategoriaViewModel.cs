using AdminGastosApp.Models;
using AdminGastosApp.Services;
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
	public partial class AgregarCategoriaViewModel : ObservableObject
	{
		private readonly DatabaseService _dbService;

		[ObservableProperty]
		private string _nombreCategoria;

		[ObservableProperty]
		private ObservableCollection<Categoria> _categorias;

		public AgregarCategoriaViewModel(DatabaseService dbService)
		{
			_dbService = dbService;
			_ = CargarCategoriasAsync();
		}

		private async Task CargarCategoriasAsync()
		{
			var lista = await _dbService.GetCategoriasAsync();
			Categorias = new ObservableCollection<Categoria>(lista);
		}

		[RelayCommand]
		private async Task GuardarCategoria()
		{
			if (string.IsNullOrWhiteSpace(NombreCategoria))
			{
				await Shell.Current.DisplayAlert("Error", "El nombre de la categoría no puede estar vacío", "OK");
				return;
			}

			var nueva = new Categoria { Nombre = NombreCategoria.Trim() };
			await _dbService.AddCategoriaAsync(nueva);

			NombreCategoria = string.Empty;
			await CargarCategoriasAsync();

			await Shell.Current.DisplayAlert("Éxito", "Categoría agregada", "OK");
		}
	}
}

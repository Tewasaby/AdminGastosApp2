using AdminGastosApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastosApp.Services
{
	public class DatabaseService
	{
		private SQLiteAsyncConnection _db;

		public DatabaseService()
		{
			Task.Run(async () => await Initialize()).Wait();
		}

		private async Task Initialize()
		{
			if (_db != null)
				return;

			var dbPath = Path.Combine(FileSystem.AppDataDirectory, "gastos.db3");
			_db = new SQLiteAsyncConnection(dbPath);
			await _db.CreateTableAsync<Gasto>();
			await _db.CreateTableAsync<Categoria>();
			await InsertarCategoriasPorDefecto();
			Debug.WriteLine($"Ruta de la BD: {dbPath}");

		}

		// CRUD
		public async Task<int> AddGastoAsync(Gasto gasto) => await _db.InsertAsync(gasto);
		public async Task<List<Gasto>> GetGastosAsync() => await _db.Table<Gasto>().ToListAsync();
		public async Task<List<Gasto>> GetGastosPorMesAsync(int year, int month)
		{
			var allGastos = await _db.Table<Gasto>().ToListAsync();
			return allGastos
				.Where(g => g.Fecha.Year == year && g.Fecha.Month == month)
				.ToList();
		}

		// Categorías

		private async Task InsertarCategoriasPorDefecto()
		{
			var existentes = await _db.Table<Categoria>().ToListAsync();

			if (existentes.Count == 0)
			{
				var categoriasPorDefecto = new List<Categoria>
			{
				new Categoria { Nombre = "Comida" },
				new Categoria { Nombre = "Transporte" },
				new Categoria { Nombre = "Ocio" },
				new Categoria { Nombre = "Salud" },
				new Categoria { Nombre = "Educación" },
				new Categoria { Nombre = "Otros" }
			};

				await _db.InsertAllAsync(categoriasPorDefecto);
			}
		}
		public async Task<int> AddCategoriaAsync(Categoria categoria) => await _db.InsertAsync(categoria);

		public async Task<List<Categoria>> GetCategoriasAsync() => await _db.Table<Categoria>().ToListAsync();

		public async Task<int> DeleteCategoriaAsync(Categoria categoria) => await _db.DeleteAsync(categoria);

		public async Task<int> UpdateCategoriaAsync(Categoria categoria) => await _db.UpdateAsync(categoria);
	}
}

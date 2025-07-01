using AdminGastosApp.Models;
using AdminGastosApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastosApp.ViewModels
{
	public partial class ResumenViewModel : ObservableObject
	{
		private readonly DatabaseService _dbService;

		[ObservableProperty]
		private Chart _chart;

		[ObservableProperty]
		private ObservableCollection<Gasto> _gastosDelMes = new();

		// Propiedades para pickers
		public List<string> Meses { get; } = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
			.Where(m => !string.IsNullOrWhiteSpace(m))
			.ToList();

		public List<int> Anios { get; } = Enumerable.Range(DateTime.Now.Year - 5, 6).ToList(); // últimos 6 años

		[ObservableProperty]
		private int mesSeleccionado;

		[ObservableProperty]
		private int anioSeleccionado;

		[ObservableProperty]
		private decimal totalDelMes;

		public ResumenViewModel(DatabaseService dbService)
		{
			_dbService = dbService;

			// Establecer valores iniciales a mes y año actual
			MesSeleccionado = DateTime.Now.Month - 1; // Picker usa index (0 = Enero)
			AnioSeleccionado = DateTime.Now.Year;

			// Cargar el resumen inicial
			_ = CargarResumenAsync();
		}

		// Llama a este método cuando cambie Mes o Año
		partial void OnMesSeleccionadoChanged(int value) => _ = CargarResumenAsync();
		partial void OnAnioSeleccionadoChanged(int value) => _ = CargarResumenAsync();

		private async Task CargarResumenAsync()
		{
			// ✅ 1. Limpiar datos y establecer Chart a null (elimina el gráfico visualmente)
			GastosDelMes.Clear();
			TotalDelMes = 0;
			Chart = null; // ⚠️ Esto hace que el ChartView se oculte

			// ✅ 2. Cargar datos en segundo plano
			int mes = MesSeleccionado + 1;
			int anio = AnioSeleccionado;

			var gastos = await _dbService.GetGastosPorMesAsync(anio, mes);

			// ✅ 3. Actualizar UI en el hilo principal
			await MainThread.InvokeOnMainThreadAsync(() =>
			{
				GastosDelMes = new ObservableCollection<Gasto>(gastos);
				TotalDelMes = gastos.Sum(g => g.Monto);
				GenerarGrafico(); // Solo se ejecuta con datos frescos
			});
		}

		private void GenerarGrafico()
		{
			// ✅ Gráfico vacío si no hay datos
			if (GastosDelMes == null || !GastosDelMes.Any())
			{
				Chart = new PieChart
				{
					Entries = new[] { new ChartEntry(0) { Color = SKColors.Transparent } },
					LabelTextSize = 20,
					BackgroundColor = SKColors.Transparent
				};
				return;
			}

			// ✅ Entradas actualizadas
			var entries = GastosDelMes
				.GroupBy(g => g.Categoria)
				.Select(g => new ChartEntry((float)g.Sum(x => x.Monto))
				{
					Label = g.Key,
					ValueLabel = g.Sum(x => x.Monto).ToString("C"),
					Color = SKColor.Parse(GetRandomColor()),
					ValueLabelColor = GetDynamicTextColor(),
					TextColor = GetDynamicTextColor()
				}).ToList();

			Chart = new PieChart
			{
				Entries = entries,
				LabelTextSize = 20,
				BackgroundColor = SKColors.Transparent,
				AnimationDuration = TimeSpan.FromMilliseconds(500) // Animación suave
			};
		}

		private string GetRandomColor()
		{
			var random = new Random();
			return $"#{random.Next(0x1000000):X6}";
		}

		private SKColor GetDynamicTextColor()
		{
			// Detecta si el tema es oscuro
			var isDark = Application.Current?.RequestedTheme == AppTheme.Dark;
			return isDark ? SKColors.White : SKColors.Black;
		}
	}
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastosApp.Models
{
	[Table("Gasto")]
	public class Gasto
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public decimal Monto { get; set; }
		public DateTime Fecha { get; set; }
		public string Categoria { get; set; } // Ej: "Comida", "Transporte"
	}
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGastosApp.Models
{
	public class Categoria
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[MaxLength(100)]
		public string Nombre { get; set; }
	}
}

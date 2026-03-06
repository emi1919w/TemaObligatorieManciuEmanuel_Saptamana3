using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TemaObligatorie_ManciuEmanuel.Models
{
	public class Order
	{
		public int ID { get; set; }

		public List<CartItem> ProduseDinCos {  get; set; }

		public decimal PretTotal {  get; set; }

		public string StatusComanda {  get; set; }

		public DateTime DataComanda { get; set; }

		public Order(int Id, List<CartItem> produseDinCos, Decimal pretTotal, string statusComanda, DateTime dataComanda)
		{ 
			ID = Id;
			ProduseDinCos = produseDinCos;
			PretTotal = pretTotal;
			StatusComanda = statusComanda;
			DataComanda = dataComanda;
		}
	}
}

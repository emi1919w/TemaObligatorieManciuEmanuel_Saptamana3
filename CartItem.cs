using System;
using System.Collections.Generic;
using System.Text;

namespace TemaObligatorie_ManciuEmanuel.Models
{
	public class CartItem
	{
		public int CantitateProdusDorit {  get; set; }
		public Product ProdusDorit { get; set; }

		public CartItem(int cantitateProdusDorit, Product produsDorit)
		{
			CantitateProdusDorit = cantitateProdusDorit;
			ProdusDorit = produsDorit;
		}
	}
}

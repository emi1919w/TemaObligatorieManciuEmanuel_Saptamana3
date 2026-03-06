using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Interfaces;
using TemaObligatorie_ManciuEmanuel.Models;

namespace TemaObligatorie_ManciuEmanuel.Services
{
	public class CargusShippingService : IShippingService
	{
		public string ExpediereComanda(Order comanda)
		{
			string nume = $"Comanda {comanda.ID} a fost preluata de Cargus!";
			return nume;
		}
	}
}

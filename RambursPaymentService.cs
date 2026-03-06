using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Interfaces;

namespace TemaObligatorie_ManciuEmanuel.Services
{
	public class RambursPaymentService : IPaymentService
	{
		public string ProceseazaPlata(decimal sumaDePlatit)
		{
			string nume = $"Plata in valoare de {sumaDePlatit} se va face ramburs!";
			return nume;
		}
	}
}

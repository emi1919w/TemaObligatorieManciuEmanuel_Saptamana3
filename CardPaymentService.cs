using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Interfaces;

namespace TemaObligatorie_ManciuEmanuel.Services
{
	public class CardPaymentService : IPaymentService
	{
		public string ProceseazaPlata(decimal sumaDePlatit)
		{
			string nume = $"Plata cu cardul in valoare de: {sumaDePlatit} a fost procesata cu suuces!";
			return nume;
		}
	}
}

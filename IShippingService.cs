using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Models;

namespace TemaObligatorie_ManciuEmanuel.Interfaces
{
	public interface IShippingService
	{
		string ExpediereComanda(Order comanda);
	}
}

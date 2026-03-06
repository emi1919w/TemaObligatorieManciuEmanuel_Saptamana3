using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Interfaces;

namespace TemaObligatorie_ManciuEmanuel.Services
{
	public class ProcentualDiscountService : IDiscountService
	{
		public decimal AplicaDiscount(decimal pretOriginal)
		{
			return pretOriginal - (pretOriginal * 10 / 100);
		}
	}
}

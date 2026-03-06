using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Interfaces;

namespace TemaObligatorie_ManciuEmanuel.Services
{
	public class FixedDiscountService : IDiscountService
	{
		public decimal AplicaDiscount(decimal pretOriginal)
		{
			decimal discount = 20;
			if(pretOriginal > 40)
				return pretOriginal - discount;
			return pretOriginal;
		}
	}
}

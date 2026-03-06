using System;
using System.Collections.Generic;
using System.Text;

namespace TemaObligatorie_ManciuEmanuel.Interfaces
{
	public interface IDiscountService
	{
		decimal AplicaDiscount(decimal pretOriginal);
	}
}

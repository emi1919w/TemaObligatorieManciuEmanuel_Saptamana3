using System;
using System.Collections.Generic;
using System.Text;
using TemaObligatorie_ManciuEmanuel.Interfaces;
using TemaObligatorie_ManciuEmanuel.Models;

namespace TemaObligatorie_ManciuEmanuel.Services
{
	public class OrderService
	{
		private readonly IPaymentService _paymentService;
		private readonly IShippingService _shippingService;
		private readonly IDiscountService _discountService;

		public OrderService(IPaymentService payment,
							IShippingService shipping,
							IDiscountService discount)
		{
			_paymentService = payment;
			_shippingService = shipping;
			_discountService = discount;
		}

		public string ProceseazaComanda(Order comanda)
		{
			decimal pretFinal = _discountService.AplicaDiscount(comanda.PretTotal);
			string rezultatPlata = _paymentService.ProceseazaPlata(pretFinal);
			string rezultatShipping = _shippingService.ExpediereComanda(comanda);

			return $"{rezultatPlata}\n{rezultatShipping}";
		}
	}
}

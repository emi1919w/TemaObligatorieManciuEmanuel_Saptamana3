using TemaObligatorie_ManciuEmanuel.Interfaces;
using TemaObligatorie_ManciuEmanuel.Models;
using TemaObligatorie_ManciuEmanuel.Repositories;
using TemaObligatorie_ManciuEmanuel.Services;

namespace TemaObligatorie_ManciuEmanuel
{
	class Program
	{

		static List<CartItem> cos = new List<CartItem>();
		static JsonProductRepository repository = new JsonProductRepository();
		static void Main(string[] args)
		{

			var produse = new List<Product>
			{
				new Product("Laptop Lenovo", "Laptop de Gaming", "Electronice", 1, 10, 2999.99m),
				new Product("Mouse ASUS", "Mouse Office", "Electronice", 2, 40, 49.99m),
				new Product("Tricou Nike", "Tricou de Bumbac", "Haine", 3, 180, 49.99m)
			};

			repository.Save(produse);


			bool running = true;
			while (running)
			{
				Console.WriteLine("1. Vezi catalog produse");
				Console.WriteLine("2. Adauga produs in cos");
				Console.WriteLine("3. Vezi cosul");             
				Console.WriteLine("4. Plaseaza comanda");
				Console.WriteLine("0. Iesire"); ;

				string optiune = Console.ReadLine();
				switch(optiune)
				{
					case "1":
						AfiseazaCatalog(repository);
						break;
					case "2":
						AdaugaInCos();
						break;
					case "3":
						AfiseazaCos();
						break;
					case "4":
						PlaseazaComanda();
						break;
					case "0":
						running = false;
						break;
					default:
						Console.WriteLine("Optiune invalida!");
						break;
				}
			}
		}

		static void AfiseazaCatalog(JsonProductRepository repository)
		{
			Console.WriteLine("\n=== Catalog Produse ===");
			foreach(var p in repository.GetAll())
				Console.WriteLine($"[{p.ID}] {p.NumeProdus} - {p.Descriere} - {p.Pret} lei");
		}

		static void PlaseazaComanda()
		{
			// Verifica daca cosul e gol
			if (cos.Count == 0)
			{
				Console.WriteLine("Cosul e gol! Adauga produse mai intai.");
				return;
			}

			// Afiseaza cosul
			AfiseazaCos();

			// Calculeaza totalul din cos
			decimal total = cos.Sum(item => item.ProdusDorit.Pret * item.CantitateProdusDorit);

			// Alege metoda de plata
			Console.WriteLine("\n1. Card\n2. Ramburs");
			Console.Write("Metoda plata: ");
			string optiunePlata = Console.ReadLine();
			IPaymentService plata = optiunePlata == "1"
				? new CardPaymentService()
				: new RambursPaymentService();

			// Alege curier
			Console.WriteLine("\n1. FanCurier\n2. Cargus\n3. SameDay");
			Console.Write("Curier: ");
			string optiuneCurier = Console.ReadLine();
			IShippingService curier = optiuneCurier switch
			{
				"1" => new FanCourierShippingService(),
				"2" => new CargusShippingService(),
				_ => new SameDayShippingService()
			};

			// Alege discount
			Console.WriteLine("\n1. Discount fix (20 lei)\n2. Discount 10%");
			Console.Write("Discount: ");
			string optiuneDiscount = Console.ReadLine();
			IDiscountService discount = optiuneDiscount == "1"
				? new FixedDiscountService()
				: new ProcentualDiscountService();

			// Creeaza comanda cu produsele din cos
			var comanda = new Order(1, cos, total, "Pending", DateTime.Now);
			var orderService = new OrderService(plata, curier, discount);
			string rezultat = orderService.ProceseazaComanda(comanda);
			Console.WriteLine($"\n=== Rezultat ===\n{rezultat}");

			// Goleste cosul dupa comanda
			cos.Clear();
			Console.WriteLine("Cosul a fost golit. Comanda plasata cu succes!");
		}

		static void AdaugaInCos()
		{
			AfiseazaCatalog(repository);
			Console.Write("ID produs dorit: ");
			int id = int.Parse(Console.ReadLine());
			var produs = repository.GetAll().FirstOrDefault(p => p.ID == id);
			if (produs == null) { Console.WriteLine("Produs negasit!"); return; }

			Console.Write("Cantitate: ");
			int cantitate = int.Parse(Console.ReadLine());

			cos.Add(new CartItem(cantitate, produs));
			Console.WriteLine($"{produs.NumeProdus} adaugat in cos!");
		}

		static void AfiseazaCos()
		{
			if (cos.Count == 0) { Console.WriteLine("Cosul e gol!"); return; }
			Console.WriteLine("\n=== Cosul tau ===");
			decimal total = 0;
			foreach (var item in cos)
			{
				decimal subtotal = item.ProdusDorit.Pret * item.CantitateProdusDorit;
				Console.WriteLine($"{item.ProdusDorit.NumeProdus} x{item.CantitateProdusDorit} = {subtotal} lei");
				total += subtotal;
			}
			Console.WriteLine($"Total: {total} lei");
		}
	}
}
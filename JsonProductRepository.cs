using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TemaObligatorie_ManciuEmanuel.Interfaces;
using TemaObligatorie_ManciuEmanuel.Models;
using System.Text.Json;

namespace TemaObligatorie_ManciuEmanuel.Repositories
{
	public class JsonProductRepository : IProductRepository
	{
		private readonly string _filePath = "products.json";

		public List<Product> GetAll()
		{
			if (!File.Exists(_filePath))
				return new List<Product>();
			

			string json = File.ReadAllText(_filePath);
			return JsonSerializer.Deserialize<List<Product>>(json)
				?? new List<Product>();
		}

		public void Save(List<Product> produse)
		{ 
			string json = JsonSerializer.Serialize(produse);
			File.WriteAllText(_filePath, json);
		}
	}
}

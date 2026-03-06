using System;
using System.Collections.Generic;
using System.Text;

namespace TemaObligatorie_ManciuEmanuel.Models
{
	public class Product
	{
		
		public string NumeProdus {  get; set; }
		public string Descriere {  get; set; }
		public string Categorie {  get; set; }

		public int ID { get; set; }

		public int CantitateInStoc {  get; set; }

		public decimal Pret {  get; set; }

		public Product(string numeProdus, string descriere, string categorie, int id, int cantitateInStoc, decimal pret)
		{ 
			NumeProdus = numeProdus;
			Descriere = descriere;
			Categorie = categorie;
			ID = id;
			CantitateInStoc = cantitateInStoc;
			Pret = pret;
		}

	}
}

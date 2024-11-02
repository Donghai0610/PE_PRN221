using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
	public class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }

		public Product()
		{
		}

		public Product(int iD, string name, double price)
		{
			ID = iD;
			Name = name;
			Price = price;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _20_July_2008
{
    class Assortment
    {
		private string name;
		private int quantity;
		private double price;
		private string code;

		public Assortment(string name, int quantity, double price, string code)
		{
			this.Name = name;
			this.Quantity = quantity;
			this.Price = price;
			this.Code = code;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public double Price
		{
			get { return price; }
			set { price = value; }
		}

		public string Code
		{
			get { return code; }
			set { code = value; }
		}

		public string GetExpiryDate()
		{
			string date;

			int year = int.Parse(this.Code.Substring(0, 2));
			int month = int.Parse(this.Code.Substring(2, 2));
			int day = int.Parse(this.Code.Substring(4, 2));
			
			date = new DateTime(year, month, day).ToString("dd.MM.yy");
			return date;
		}

		public new string GetType()
		{
			string typeByCode = this.Code.Substring(6, 1);
			string type = null;

			switch (typeByCode)
			{
				case "1":
					code = "appetizer";
					break;
				case "2":
					code = "main dish";
					break;
				case "3":
					code = "dessert";
					break;
				case "4":
					code = "non-alcoholic drink";
					break;
				case "5":
					code = "alcohol";
					break;
				default:
					break;
			}
			return type;
		}

		public int GetNumber()
		{
			string number = this.Code.Substring(7, 3);
			return int.Parse(number);
		}

		public override string ToString()
		{
			string printText = $"{Name}, {GetType()}, {Quantity}, {Price:F2}";
			return printText;
		}
	}
}

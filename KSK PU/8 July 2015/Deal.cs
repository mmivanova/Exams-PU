using System;
using System.Collections.Generic;
using System.Text;

namespace _8_July_2015
{
    class Deal
    {
		private DateTime date;
		private int code;
		private int quantity;
		private int quality;
		private string name;

		public Deal(DateTime dateOfDeal, int code, int quantity, int quality, string name)
		{
			this.DateOfDeal = dateOfDeal;
			this.Code = code;
			this.Quantity = quantity;
			this.Quality = quality;
			this.Name = name;
		}

		public DateTime DateOfDeal
		{
			get { return date; }
			set { date = value; }
		}

		public int Code
		{
			get { return code; }
			set { code = value; }
		}

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public int Quality
		{
			get { return quality; }
			set { quality = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public double QuantityInKG => Quantity * 0.001;

		public string GetType()
		{
			int typeByInt = this.Code;
			string type = null;

			switch (typeByInt)
			{
				case 1:
					type = "манатарка";
					break;
				case 2:
					type = "печурка";
					break;
				case 3:
					type = "кладница";
					break;
				case 4:
					type = "пачи крак";
					break;
				case 5:
					type = "сърнела";
					break;
				case 6:
					type = "друг вид";
					break;
				default:
					break;
			}
			return type;
		}

		public override string ToString()
		{
			string printText = DateOfDeal.ToString("dd.MM.yyyy HH:mm") + ", " +	GetType() + ", " +	QuantityInKG + "кг., "+ Quality + "-во, " + Name;
			return printText;
		}
	}
}

using System;


namespace _1_June_2010
{
    class Vehicle
    {
		private string brand;
		private string colour;
		private double dailyPrice;
		private string iDNumber;

		public Vehicle(string brand, string colour, double dailyPrice, string iDNumber)
		{
			this.Brand = brand;
			this.Colour = colour;
			this.DailyPrice = dailyPrice;
			this.IDNumber = iDNumber;
		}

		public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}

		public string Colour
		{
			get { return colour; }
			set { colour = value; }
		}

		public double DailyPrice
		{
			get { return dailyPrice; }
			set { dailyPrice = value; }
		}

		public string IDNumber
		{
			get { return iDNumber; }
			set { iDNumber = value; }
		}

		public string GetCountry()
		{
			string code = this.IDNumber.Substring(0, 1);
			string country = null;

			switch (code)
			{
				case "1":
					country = "France";
					break;
				case "2":
					country = "Italy";
					break;
				case "3":
					country = "Austria";
					break;
				case "4":
					country = "Germany";
					break;
				case "5":
					country = "Spain";
					break;
				case "6":
					country = "England";
					break;
				default:
					break;
			}
			return country;
		}

		public new string GetType()
		{
			string typeCode = this.IDNumber.Substring(1, 1);
			string type = null;

			switch (typeCode)
			{
				case "1":
					type = "small";
					break;
				case "2":
					type = "compact";
					break;
				case "3":
					type = "medium";
					break;
				case "4":
					type = "van";
					break;
				case "5":
					type = "jeep";
					break;
				default:
					break;
			}
			return type;
		}

		public string GetDate()
		{
			string date;

			int year = int.Parse(this.IDNumber.Substring(6, 2));
			int month = int.Parse(this.IDNumber.Substring(4, 2));
			int day = int.Parse(this.IDNumber.Substring(2, 2));

			date = new DateTime(year, month, day).ToString("dd.MM.yy");
			return date;
		}

		public override string ToString()
		{
			string printText = $"{Brand}, {GetType()}, {Colour}, {DailyPrice:F2}, {GetDate()}";
			return printText;
		}
	}
}

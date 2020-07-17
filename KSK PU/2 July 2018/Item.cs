using System;
using System.Collections.Generic;

namespace _2_July_2018
{
    class Item
    {
		public Item(string position, string code, string name, double quantity, DateTime date, int suitability)
		{
			this.Position = position;
			this.Code = code;
			this.Name = name;
			this.Quantity = quantity;
			this.DateOfEntry = date;
			this.Suitability = suitability;
			this.Group = 'S';
		}

		public Item(string position, string code, string name, double quantity, DateTime date, int suitability, int humidity)
		{
			this.Position = position;
			this.Code = code;
			this.Name = name;
			this.Quantity = quantity;
			this.DateOfEntry = date;
			this.Suitability = suitability;
			this.Humidity = humidity;
			this.Group = 'E';
		}

		private string code;
		private string name;
		private double quantity;
		private int suitability;
		private char group;
		private DateTime dateOfEntry;
		private string position;
		private int humidity;

		public string Code
		{
			get { return code; }
			set { code = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public double Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}
		
		public int Suitability
		{
			get { return suitability; }
			set { suitability = value; }
		}

		public char Group
		{
			get { return group; }
			set { group = value; }
		}

		public DateTime DateOfEntry
		{
			get { return dateOfEntry; }
			set { dateOfEntry = value; }
		}

		public string Position
		{
			get { return position; }
			set { position = value; }
		}

		public int Humidity
		{
			get { return humidity; }
			set { humidity = value; }
		}

		public override string ToString()
		{
			string printText = null ;
			if (this.Group == 'E')
			{
				printText = $"{Position}, {Code}, {Name}, {Quantity:F2}, {DateOfEntry:dd.MM.yyyy}, {Suitability}, B%= {Humidity}";
			}
			else if(this.Group == 'S')
			{
				printText = $"{Position}, {Code}, {Name}, {Quantity:F2}, {DateOfEntry:dd.MM.yyyy}, {Suitability}";
			}
			return printText;
		}
	}
}

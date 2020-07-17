using System;
using System.Collections.Generic;
using System.Text;

namespace _4_June_2015
{
    class Pet
    {
		private string name;
		private string type;
		private int months;
		private string owner;

		public Pet(string name, string type, int months, string owner)
		{
			this.Name = name;
			this.Type = type;
			this.Months = months;
			this.Owner = owner;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		public int Months
		{
			get { return months; }
			set { months = value; }
		}

		public string Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		public double Age => Months / 12;

		public override string ToString()
		{
			string printText = $"{Name}, {Type}, {Age:F0} г. и {Months - (Age*12)} мес., {Owner}";
			return printText;
		}
	}
}

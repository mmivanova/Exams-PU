using System;
using System.Collections.Generic;
using System.Text;

namespace _4_June_2019
{
    class Star
    {
		public Star(string name, double distance, int classification , double weight, string nameOfConstellation)
		{
			this.Name = name;
			this.Distance = distance;
			this.Class = classification;
			this.Weight = weight;
			this.NameOfConstellation = nameOfConstellation;
		}

		private string name;
		private double distance;
		private double weight;
		private string nameOfConstellation;
		private int classification;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public double Distance
		{
			get { return distance; }
			set { distance = value; }
		}

		public double Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public string NameOfConstellation
		{
			get { return nameOfConstellation; }
			set { nameOfConstellation = value; }
		}

		public int Class
		{
			get { return classification; }
			set { classification = value; }
		}

		public string GetClassification()
		{
			int classByNumber = this.Class;
			string classification = null;
			switch (classByNumber)
			{
				case 1:
					classification = "хипергиганти";
					break;
				case 2:
					classification = "свръхгиганти";
					break;
				case 3:
					classification = "ярки гиганти";
					break;
				case 4:
					classification = "гиганти";
					break;
				case 5:
					classification = "субгиганти";
					break;
				case 6:
					classification = "джуджета";
					break;
				case 7:
					classification = "субджуджета";
					break;
				case 8:
					classification = "червени джуджета";
					break;
				case 9:
					classification = "кафяви джуджета";
					break;
				default:
					break;
			}

			return classification;
		}

		public override string ToString()
		{
			string printText = $"{Name}, {Distance:F2} св.г., {GetClassification()}, {Weight} сл.м., {NameOfConstellation}";
			return printText;
		}
	}
}

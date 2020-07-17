using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13_July_2010
{
    class Competitor
    {
		private string name;
		private string code;
		private string talant;
		private int score;

		public Competitor(string name, string code, string talant, int score)
		{
			this.Name = name;
			this.Code = code;
			this.Talant = talant;
			this.Score = score;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Code
		{
			get { return code; }
			set { code = value; }
		}

		public string Talant
		{
			get { return talant; }
			set { talant = value; }
		}

		public int Score
		{
			get { return score; }
			set { score = value; }
		}

		public int GetNumber()
		{
			string number = this.Code.Substring(0, 3);
			return int.Parse(number);
		}

		public string GetRegion()
		{
			string code = this.Code.Substring(3, 1);
			string region = null;

			switch (code)
			{
				case "1":
					region = "Sofia";
					break;
				case "2":
					region = "Plovdiv";
					break;
				case "3":
					region = "Varna";
					break;
				case "4":
					region = "Burgas";
					break;
				case "5":
					region = "Ruse";
					break;
				case "6":
					region = "Blagoevgrad";
					break;
				default:
					break;
			}
			return region;
		}

		public string GetDateOfBirth()
		{
			string date;

			int day = int.Parse(this.Code.Substring(4, 2));
			int month = int.Parse(this.Code.Substring(6, 2));
			int year = int.Parse(this.Code.Substring(8, 2));
			date = new DateTime(year, month, day).ToString("dd.MM.yy");

			return date;
		}

		public int GetBirthYear()
		{
			int year = int.Parse(this.Code.Substring(8, 2));
			if (year >= 0 && year < 20 )
			{
				year += 2000;
			}
			else
			{
				year += 1900;
			}
			return year;
		}

		public string GetFirstName()
		{
			string[] name = this.Name.Split(" ").ToArray();
			string firstName = name[0];
			return firstName;
		}

		public string GetMiddleNamesInitial()
		{
			string[] name = this.Name.Split(" ").ToArray();
			string initial = name[1].Substring(0, 1);
			return initial;
		}

		public string GetLastName()
		{
			string[] name = this.Name.Split(" ").ToArray();
			string lastName = name[2];
			return lastName;
		}

		public string GetFullName()
		{
			return $"{GetFirstName()} {GetMiddleNamesInitial()}. {GetLastName()}";
		}

		public override string ToString()
		{
			string printText = $"{GetFullName()}, {GetNumber()}, {GetRegion()}, {Talant}, {Score}, {GetDateOfBirth()}";
			return printText;
		}
	}
}

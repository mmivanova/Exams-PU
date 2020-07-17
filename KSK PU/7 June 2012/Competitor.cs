using System;
using System.Collections.Generic;
using System.Text;

namespace _7_June_2012
{
    class Competitor
    {
		private string name;
		private string city;
		private string school;
		private int result;

		public Competitor(string name, string city, string school, int result)
		{
			this.Name = name;
			this.City = city;
			this.School = school;
			this.Result = result;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string City
		{
			get { return city; }
			set { city = value; }
		}

		public string School
		{
			get { return school; }
			set { school = value; }
		}

		public int Result
		{
			get { return result; }
			set { result = value; }
		}

		public override string ToString()
		{
			string printText = $"{Name}, {City}, {School}, {Result} точки";
			return printText;
		}
	}
}

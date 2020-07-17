using System;
using System.Collections.Generic;
using System.Text;

namespace _1_June_2011
{
    class Movie
    {
		private string title;
		private string actors;
		private int year;
		private double license;

		public Movie(string title, string actors, int yearOfRelease, double license)
		{
			this.Title = title;
			this.Actors = actors;
			this.YearOfRelease = yearOfRelease;
			this.License = license;
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string Actors
		{
			get { return actors; }
			set { actors = value; }
		}

		public int YearOfRelease
		{
			get { return year; }
			set { year = value; }
		}

		public double License
		{
			get { return license; }
			set { license = value; }
		}

		public override string ToString()
		{
			string printText = $"{Title}; {Actors}; {YearOfRelease}; {License}";
			return printText;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _8_July_2012
{
    class Book
    {
		private string title;
		private string author;
		private string publisher;
		private int year;
		private double price;
		private int number;

		public Book(string title, string author, string publisher, int yearOfRelease, double price, int numberOfBooks)
		{
			this.Title = title;
			this.Author = author;
			this.Publisher = publisher;
			this.YearOfRelease = yearOfRelease;
			this.Price = price;
			this.NumberOfBooks = numberOfBooks;
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string Author
		{
			get { return author; }
			set { author = value; }
		}

		public string Publisher
		{
			get { return publisher; }
			set { publisher = value; }
		}

		public int YearOfRelease
		{
			get { return year; }
			set { year = value; }
		}

		public double Price
		{
			get { return price; }
			set { price = value; }
		}

		public int NumberOfBooks
		{
			get { return number; }
			set { number = value; }
		}

		public override string ToString()
		{
			string printText = $"{Title}; {Author}; {Publisher}; {YearOfRelease}; {Price} лв.; {NumberOfBooks} екз.";
			return printText;
		}
	}
}

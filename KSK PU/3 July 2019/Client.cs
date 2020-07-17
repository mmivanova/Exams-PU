using System;

namespace _3_July_2019
{
	class Client
    {
		private string fullName;
		private DateTime date;
		private int number;
		private decimal sum;

		public Client(string name, DateTime dateOfRegistration, int numberOfPurchases, decimal totalSumOfPurchases)
		{
			Name = name;
			DateOfRegistration = dateOfRegistration;
			NumberOfPurchases = numberOfPurchases;
			TotalSumOfPurchases = totalSumOfPurchases;
		}

		public string Name
		{
			get { return fullName; }
			set { fullName = value; }
		}
		
		public DateTime DateOfRegistration
		{
			get { return date; }
			set { date = value; }
		}

		public int NumberOfPurchases
		{
			get { return number; }
			set { number = value; }
		}

		public decimal TotalSumOfPurchases
		{
			get { return sum; }
			set { sum = value; }
		}

		public string GetRating()
		{
			if (this.NumberOfPurchases >= 1 && this.NumberOfPurchases <=99)
			{
				return "*";
			}
			if (this.NumberOfPurchases >= 100 && this.NumberOfPurchases <= 299)
			{
				return "**";
			}
			if (this.NumberOfPurchases >= 300 && this.NumberOfPurchases <= 499)
			{
				return "***";
			}
			if (this.NumberOfPurchases >= 500 && this.NumberOfPurchases <= 999)
			{
				return "****";
			}
			else
			{
				return "*****";
			}
		}

		public override string ToString()
		{
			string output = Name + ", " + NumberOfPurchases + ", " + TotalSumOfPurchases + ", " + DateOfRegistration.ToString("dd.MM.yyyy") +", " + GetRating();
			return output.ToString();
		}
	}
}

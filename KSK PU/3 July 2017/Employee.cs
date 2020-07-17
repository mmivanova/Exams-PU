using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace _3_July_2017
{
    class Employee
    {
		private string name;
		private string personalID;
		private string nameInLatin;
		private string country;
		private string postCode;
		private string city;

		public Employee(string name, string personalID, string nameInLatin, string country, string postCode, string city)
		{
			this.Name = name;
			this.PersonalID = personalID;
			this.NameInLatin = nameInLatin;
			this.Country = country;
			this.PostCode = postCode;
			this.City = city;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string PersonalID
		{
			get { return personalID; }
			set { personalID = value; }
		}

		public string NameInLatin
		{
			get { return nameInLatin; }
			set { nameInLatin = value; }
		}
					
		public string Country
		{
			get { return country; }
			set { country = value; }
		}

		public string PostCode
		{
			get { return postCode; }
			set { postCode = value; }
		}

		public string City
		{
			get { return city; }
			set { city = value; }
		}

		public string PlaceOfResidence => Country + ", " + PostCode + ", " + City;

		public string GenerateEmail()
		{
			string surname;
			string middleName;
			string firstName;
			string email = null;
			if (NameInLatin != null || NameInLatin.Length != 0)
			{
				string[] name = NameInLatin.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
				if (name.Length == 1)
				{
					surname = name[0];
					email = $"{surname}@nncomputers.com";

				}
				else if (name.Length == 2)
				{
					firstName = name[0];
					surname = name[1];
					email = $"{surname}_{firstName}@nncomputers.com";
				}
				else if (name.Length == 3)
				{
					firstName = name[0];
					middleName= name[1];
					surname = name[2];
					email = $"{surname}_{firstName}_{middleName.ElementAt(0)}@nncomputers.com";
				}
			}
			
			return email;
		}

		public override string ToString()
		{
			string printText = Name + ", " + PersonalID + ", " + NameInLatin + ", " + PlaceOfResidence;
			return printText;
		}
	}
}

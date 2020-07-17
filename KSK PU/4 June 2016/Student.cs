using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _4_June_2016
{
    class Student
    {
		private string name;
		private string specialty;
		private double grade;
		private string type;

		public Student(string name, string specialty, double grade, string typeOfEducation)
		{
			this.Name = name;
			this.Specialty = specialty;
			this.Grade = grade;
			this.TypeOfEducation = typeOfEducation;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Specialty
		{
			get { return specialty; }
			set { specialty = value; }
		}
		
		public double Grade
		{
			get { return grade; }
			set { grade = value; }
		}

		public string TypeOfEducation
		{
			get { return type; }
			set { type = value; }
		}

		public double Bal => 6 * Grade;

		public override string ToString()
		{
			string printText = Name + "; " + Specialty + "; " + TypeOfEducation + "; " + Bal;
			return printText;
		}
	}
}

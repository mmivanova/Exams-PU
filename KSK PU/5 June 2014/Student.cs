using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5_June_2014
{
    class Student
    {
		private string facultyNumber;
		private string name;
		private int grade;
		private string teacher;

		public Student(string facultyNumber, string name, int grade, string teacher)
		{
			this.FacultyNumber = facultyNumber;
			this.Name = name;
			this.Grade = grade;
			this.Teacher = teacher;
		}

		public string FacultyNumber
		{
			get { return facultyNumber; }
			set { facultyNumber = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Grade
		{
			get { return grade; }
			set { grade = value; }
		}

		public string Teacher
		{
			get { return teacher; }
			set { teacher = value; }
		}

		public char GetFirstNameInitial()
		{
			string[] name = this.Teacher.Split(" ").ToArray();
			string firstName = name[0];
			char initial = char.Parse(firstName.Substring(0, 1));
			return initial;
		}

		public char GetMiddleNameInitial()
		{
			string[] name = this.Teacher.Split(" ").ToArray();
			string middleName = name[1];
			char initial = char.Parse(middleName.Substring(0, 1));
			return initial;
		}

		public string GetLastName()
		{
			string[] name = this.Teacher.Split(" ").ToArray();
			string lastName = name[2];
			return lastName;
		}

		public override string ToString()
		{
			string printText = $"{FacultyNumber}, {Name}, {Grade}, {GetFirstNameInitial()}. {GetMiddleNameInitial()}. {GetLastName()}";
			return printText;
		}
	}
}

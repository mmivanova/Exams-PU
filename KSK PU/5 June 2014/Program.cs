using System;
using System.Collections.Generic;

namespace _5_June_2014
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            do
            {
                Console.Write("Enter the number of students: ");
                number = int.Parse(Console.ReadLine());
            } while (number <= 0 || number > 40);

            List<Student> students = new List<Student>();
            Input(number, students);
        }

        private static void Input(int number, List<Student> students)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string facultyNumber;
                int grade;
                string teacher;

                do
                {
                    Console.Write("Faculty number: ");
                    facultyNumber = Console.ReadLine();
                } while (facultyNumber.Length <= 0 || facultyNumber.Length > 10);

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 40);

                do
                {
                    Console.Write("Grade: ");
                    grade = int.Parse(Console.ReadLine());
                } while (grade <= 0 || grade > 6);

                do
                {
                    Console.Write("Teacher: ");
                    teacher = Console.ReadLine();
                } while (teacher.Length <= 0 || teacher.Length > 40);

                Student student = new Student(facultyNumber, name, grade, teacher);
                students.Add(student);
            }
        }

        private static void Output(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public static List<Student> SortByGrade(List<Student> students)
        {
            Student temp;

            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - 1 - i; j++)
                {
                    if (students[j].Grade.CompareTo(students[j+1].Grade) < 0 || (
                        students[j].Grade.CompareTo(students[j + 1].Grade) == 0 &&
                        students[j].Name.CompareTo(students[j + 1].Name) > 0))
                    {
                        temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
            return students;
        }

        public static List<Student> DimoStudents(List<Student> students)
        {
            List<Student> dimoStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.Name.Contains("димо") || student.Name.Contains("Димо"))
                {
                    dimoStudents.Add(student);
                }
            }
            return SortByGrade(dimoStudents);
        }
    }
}

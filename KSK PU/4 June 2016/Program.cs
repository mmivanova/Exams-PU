using System;
using System.Collections.Generic;

namespace _4_June_2016
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
            } while (number < 5 || number > 550);

            List<Student> students = new List<Student>();
            Input(number, students);

            List<Student> sortBySpecialty = SortBySpecialty(students);
            Output(sortBySpecialty);

            Console.Write("Enter specialty: ");
            string specialty = Console.ReadLine();
            Console.Write("Enter type of education: ");
            string type = Console.ReadLine();


        }

        private static void Input(int number, List<Student> students)
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                string specialty;
                double grade;
                string type;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length <= 0 || name.Length > 30);

                do
                {
                    Console.Write("Specialty: ");
                    specialty = Console.ReadLine();
                } while (specialty.Length <= 0 || specialty.Length > 20);

                Console.Write("Grade: ");
                grade = double.Parse(Console.ReadLine());

                do
                {
                    Console.Write("Type of education: ");
                    type = Console.ReadLine();
                } while (type.Length <= 0 || type.Length > 15);

                Student student = new Student(name, specialty, grade, type);
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

        public static List<Student> SortBySpecialty(List<Student> students)
        {
            Student temp;

            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - 1 - i; j++)
                {
                    if (students[j].Specialty.CompareTo(students[j+1].Specialty) > 0 || (
                        students[j].Specialty.CompareTo(students[j + 1].Specialty) == 0) &&
                        students[j].Bal.CompareTo(students[j + 1].Bal) < 0)
                    {
                        temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
            return students;
        }

        public static List<Student> Inquiry(List<Student> students, string specialty, string type)
        {
            List<Student> newListOfStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.Specialty.Equals(specialty) && student.TypeOfEducation.Equals(type))
                {
                    newListOfStudents.Add(student);
                }
            }
            return SortByName(newListOfStudents);
        }

        private static List<Student> SortByName(List<Student> students)
        {
            Student temp;

            for (int i = 0; i < students.Count - 1; i++)
            {
                for (int j = 0; j < students.Count - 1 -i; j++)
                {
                    if (students[j].Name.CompareTo(students[j+1].Name) > 0)
                    {
                        temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
            return students;
        }
    }
}

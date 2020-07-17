using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_June_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.Write("Enter the number of operations: ");
                number = int.Parse(Console.ReadLine());
            } while (number < 0 || number >= 1000);

            List<Operation> listOfOperations = new List<Operation>();
            Input(number, listOfOperations);

            Console.WriteLine();
            
            Output(SortByDate(listOfOperations));
            Console.WriteLine();

            SortByOperator(listOfOperations);
            Console.WriteLine();

            Inquiry(listOfOperations);
        }

        private static void Input(int number, List<Operation> operations )
        {
            for (int i = 0; i < number; i++)
            {
                string name;
                DateTime date;
                int type;
                string comment;

                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                } while (name.Length < 0 || name.Length > 100);

                Console.Write("Date and time (e.g. 2020/06/25 12:58): ");
                char[] separators = new char[] { '/', ':', ' ' };
                int[] dateInput = Console.ReadLine().Split(separators).Select(int.Parse).ToArray();
                date = new DateTime(dateInput[0], dateInput[1], dateInput[2], dateInput[3], dateInput[4], 00);

                do
                {
                    Console.Write("Type of operation: ");
                    type = int.Parse(Console.ReadLine());
                } while (type < 0 || type > 4);

                do
                {
                    Console.Write("Comment: ");
                    comment = Console.ReadLine();
                } while (comment.Length < 0 || comment.Length > 100);

                Operation operation = new Operation(name, date, type, comment);
                operations.Add(operation);
            }
        }

        private static void Output(List<Operation> operations)
        {
            foreach (var operaion in operations)
            {
                Console.WriteLine(operaion);
            }
        }

        public static List<Operation> SortByDate(List<Operation> operations)
        {
            Operation temp;

            for (int i = 0; i < operations.Count - 1; i++)
            {
                for (int j = 0; j < operations.Count - 1 - i; j++)
                {
                    if (operations[j].Date.CompareTo(operations[j + 1].Date) > 0)
                    {
                        temp = operations[j];
                        operations[j] = operations[j + 1];
                        operations[j + 1] = temp;
                    }
                }
            }

            return operations;
        }

        public static void SortByOperator(List<Operation> operations)
        {
            Operation temp;

            for (int i = 0; i < operations.Count - 1; i++)
            {
                for (int j = 0; j < operations.Count - 1 - i; j++)
                {
                    if (operations[j].Operator.CompareTo(operations[j + 1].Operator) > 0 ||
                        operations[j].Operator.CompareTo(operations[j + 1].Operator) == 0 &&
                        operations[j].Comment.CompareTo(operations[j + 1].Comment) > 0)
                    {
                        temp = operations[j];
                        operations[j] = operations[j + 1];
                        operations[j + 1] = temp;
                    }
                }
            }

            int number = 1;
            foreach (var operation in operations)
            {
                Console.WriteLine(number + ". " + operation);
                number++;
            }
        }

        public static void Inquiry(List<Operation> operations)
        {
            string currentOperator = null;
            string bestOperator = null;
            int currentCount = 0;
            int bestCount = 0;
            foreach (var operation in operations)
            {
                currentOperator = operation.Operator;
                currentCount++;
                if (currentCount > bestCount)
                {
                    bestOperator = currentOperator;
                    bestCount = currentCount;
                }
            }

            int typeOneCounter = 0;
            int typeFourCounter = 0;

            foreach (var operation in operations.Where(i => i.Operator.Equals(bestOperator)))
            {
                if (operation.Type == 4)
                {
                    typeFourCounter++;
                }
                if (operation.Type == 1)
                {
                    typeOneCounter++;
                }
            }

            Console.WriteLine("Operator: " + bestOperator + Environment.NewLine +  
                              "Number of Type Four operations: " + typeFourCounter + Environment.NewLine + 
                              "Number of Type One operations: " + typeOneCounter);
        }
    }
}

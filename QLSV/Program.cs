using System;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApplication3.controller;
using ConsoleApplication3.model;
using QLSV.controller;

namespace ConsoleApplication3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        StudentController studentController = new StudentController();
        TeacherController teacherController = new TeacherController();
            while (true)
            {
                Console.WriteLine("----------Teacher Management---------");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1. Create student.");
                Console.WriteLine("2. Show list student.");
                Console.WriteLine("3. Show detail information student.");
                Console.WriteLine("4. Update list student.");
                Console.WriteLine("5. Delete student.");
                Console.WriteLine("6. Exit program.");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Please enter your choice (1 to 6):");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        studentController.createStudent();
                        break;
                    case 2:
                        studentController.showList();
                        break;
                    case 3:
                        studentController.showDetail();
                        break;

                    case 4:
                        studentController.Update();

                        break;
                    case 5:
                        studentController.Delete();
                        break;
                    case 6:
                        Console.WriteLine("See you again: ");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!!Please choose again!!!");
                        break;
                }

                Console.ReadLine();
                if (choice == 6)
                {
                    break;
                }
            }
        }
    }
}
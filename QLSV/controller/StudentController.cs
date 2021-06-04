using System;
using System.Collections.Generic;
using ConsoleApplication3.model;
using QLSV.model;

namespace QLSV.controller
{
    public class StudentController
    {
        private StudentModel studentModel = new StudentModel();
        public bool createStudent()
        {
            Student student = new Student();
            Console.WriteLine("Please enter information student!");
            Console.WriteLine("Enter roll number: ");
            student.RollNumber = Console.ReadLine();
            Console.WriteLine("Enter firstname student: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter lastname student: ");
            student.LastName = Console.ReadLine();
            student.Status = 1;
            studentModel.save(student);
            return true;
        }

        public void showList()
        {
            List<Student> listDatabase = studentModel.getListStudents();
            Console.WriteLine("List of student just entered is: ");
            for (int i = 0; i < listDatabase.Count; i++)
            {
                Console.WriteLine(
                    $"Student code is:  {listDatabase[i].RollNumber}, {listDatabase[i].FirstName},{listDatabase[i].LastName},{listDatabase[i].Status}");
            }
        }

        public void showDetail()
        {
            Console.WriteLine("Please enter student id to show detail:");
            string rollNumber = Console.ReadLine();
            Student t = new StudentModel().FindById(rollNumber);
            if (t == null)
            {
                Console.WriteLine("Student is not found");
            }
            else
            {
                Console.WriteLine(
                    $"Found student: FirstName {t.FirstName}, LastName{t.LastName},  Status{t.Status}");
            }
        }

        public void Update()
        {
            Console.WriteLine("Please enter student id to update:");
            string rollNumber = Console.ReadLine();
            Student t = new StudentModel().FindById(rollNumber);
            if (t == null)
            {
                Console.WriteLine("Students is not found");
            }
            else
            {
                Console.WriteLine(
                    $"Found student: FirstName {t.FirstName}, LastName{t.LastName}, Status{t.Status}");
                Console.WriteLine("Please enter information to update: ");
                Student updateStudent = new Student();
                Console.WriteLine("Enter the student new lastname: ");
                updateStudent.LastName = Console.ReadLine();
                Console.WriteLine("Enter the student new lastname: ");
                updateStudent.LastName = Console.ReadLine();
                Console.WriteLine("Enter the student new status: ");
                updateStudent.Status = Convert.ToInt32(Console.ReadLine());
                studentModel.Update(rollNumber,updateStudent);
                Console.WriteLine("Update success");
            }
        }


        public void Delete()
        {
            Console.WriteLine("Please enter students to delete:");
            string rollNumber = Console.ReadLine();
            Student t = new StudentModel().FindById(rollNumber);
            if (t == null)
            {
                Console.WriteLine("Student is not found");
            }

            else
            {
                Console.WriteLine(
                    $"Found student: FirstName {t.FirstName}, LastName{t.LastName}, Status{t.Status}");
                Console.WriteLine("Are you sure (y/n)");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    bool result = studentModel.Delete(rollNumber);
                    if (result)
                    {
                        Console.WriteLine("Delete success");
                    }
                }
            }
        }
    }
}
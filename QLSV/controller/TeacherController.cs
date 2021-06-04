using System;
using System.Collections.Generic;
using ConsoleApplication3.model;

namespace ConsoleApplication3.controller
{
    public class TeacherController
    {
        private TeacherModel teacherModel = new TeacherModel();
        private List<Teacher> list = new List<Teacher>();

        public bool createTeacher()
        {
            Teacher student = new Teacher();
            Console.WriteLine("Please enter information teacher. ");
            Console.WriteLine("Enter firstname teacher: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Enter lastname teacher: ");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Enter email teacher: ");
            student.Email = Console.ReadLine();
            Console.WriteLine("Enter address teacher: ");
            student.Address = Console.ReadLine();
            Console.WriteLine("Enter status teacher: ");
            student.Status = Convert.ToInt32(Console.ReadLine());
            teacherModel.save(student);
            return true;
        }

        public void showList()
        {
            List<Teacher> listDatabase = teacherModel.getListTeacher();
            Console.WriteLine("List of teachers just entered is: ");
            for (int i = 0; i < listDatabase.Count; i++)
            {
                Console.WriteLine(
                    $"Teacher code is:  {listDatabase[i].Id}, {listDatabase[i].FirstName},{listDatabase[i].LastName},{listDatabase[i].Email},{listDatabase[i].Address},{listDatabase[i].Status}");
            }
        }

        public void showDetail()
        {
            Console.WriteLine("Please enter teacher id to show detail:");
            int id = Convert.ToInt32(Console.ReadLine());
            Teacher t = new TeacherModel().FindById(id);
            if (t != null)
            {
                Console.WriteLine("Teacher is not found");
            }
            else
            {
                Console.WriteLine(
                    $"Found teacher: FirstName {t.FirstName}, LastName{t.LastName}, Email{t.Email}, Address{t.Address}, Status{t.Status}");
            }
        }

        public void Update()
        {
            Console.WriteLine("Please enter teacher id to update:");
            int id = Convert.ToInt32(Console.ReadLine());
            Teacher t = new TeacherModel().FindById(id);
            if (t != null)
            {
                Console.WriteLine("Teacher is not found");
            }
            else
            {
                Console.WriteLine(
                    $"Found teacher: FirstName {t.FirstName}, LastName{t.LastName}, Email{t.Email}, Address{t.Address}, Status{t.Status}");
                Console.WriteLine("Please enter information to update: ");
                Teacher updateStudent = new Teacher();
                Console.WriteLine("Enter the teachers new lastname: ");
                updateStudent.LastName = Console.ReadLine();
                Console.WriteLine("Enter the teachers new lastname: ");
                updateStudent.LastName = Console.ReadLine();
                Console.WriteLine("Enter the teachers new address: ");
                updateStudent.Address = Console.ReadLine();
                Console.WriteLine("Enter the teachers new email: ");
                updateStudent.Email = Console.ReadLine();
                Console.WriteLine("Enter the teachers new status: ");
                updateStudent.Status = Convert.ToInt32(Console.ReadLine());
                bool result = teacherModel.Update(id, updateStudent);
                if (result)
                {
                    Console.WriteLine("Update success");
                }
            }
        }


        public void Delete()
        {
            Console.WriteLine("Please enter teacher to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            Teacher t = new TeacherModel().FindById(id);
            if (t != null)
            {
                Console.WriteLine("Teacher is not found");
            }

            else
            {
                Console.WriteLine(
                    $"Found teacher: FirstName {t.FirstName}, LastName{t.LastName}, Email{t.Email}, Address{t.Address}, Status{t.Status}");
                Console.WriteLine("Are you sure (y/n)");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    bool result = teacherModel.Delete(id);
                    if (result)
                    {
                        Console.WriteLine("Delete success");
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace QLSV.model
{
    public class StudentModel
    {
        private const string DatabaseName = "qlsv";
        private const string SeverName = "localhost";
        private const string SeverPort = "3306";
        private const string Uid = "root";
        private const string Password = "";
        private const string SslMode = "none";
        private const string  PersistSecurityInfo  = "True";
         public bool save(Student student)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd =
                new MySqlCommand(
                    $"insert into `students` (`rollnumber`, `firstName` ,`lastName` ,`status`) values ('{student.RollNumber}', '{student.FirstName}', '{student.LastName}', {student.Status})", connection);
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }

        public List<Student> getListStudents()
        {
            List<Student> list = new List<Student>();
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"select * from `students`", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string rollnumber = reader.GetString("rollnumber");
                string firstName = reader.GetString("firstName");
                string lastName = reader.GetString("lastName");
                int status = reader.GetInt32("status");
                Student student = new Student();
                student.RollNumber = rollnumber;
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Status = status;
                list.Add(student);
            }

            return list;
        }

        public Student FindById(string id)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"select * from students where rollnumber = {id}", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Student s = new Student();
                s.RollNumber = reader.GetString("rollnumber");
                s.FirstName = reader.GetString("firstName");
                s.LastName = reader.GetString("lastName");
                s.Status = reader.GetInt32("status");
                return s;
            }
            else
            {
                return null;
            }
        }

        public void Update(string rollNumber, Student updateStudent)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                $"update students set `firstname` = '{updateStudent.FirstName}',`lastname`='{updateStudent.LastName}',`status`='{updateStudent.Status}' where `rollnumber`={rollNumber}",
                connection);
            int result = cmd.ExecuteNonQuery();
        }

        public bool Delete(string rollNumber)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"delete from students where `rollnumber`={rollNumber}", connection);
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
        
    }
}

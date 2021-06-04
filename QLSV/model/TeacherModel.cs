using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApplication3.model
{
    public class TeacherModel
    {
         private const string DatabaseName = "qlsv";
        private const string SeverName = "localhost";
        private const string SeverPort = "3306";
        private const string Uid = "root";
        private const string Password = "";
        private const string SslMode = "none";
        private const string PersistSecurityInfo = "True";

        public bool save(Teacher teacher)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd =
                new MySqlCommand(
                    $"insert into `teachers` (`id`, `firstName`,`lastName` , `email` , `address`,`status`) values ('{teacher.Id}','{teacher.FirstName}' ,`{teacher.LastName}`,'{teacher.Email}', {teacher.Address} )",
                    connection);
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }

        public List<Teacher> getListTeacher()
        {
            List<Teacher> list = new List<Teacher>();
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"select * from `teachers`", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string firstName = reader.GetString("firstName");
                string lastName = reader.GetString("lastName");
                string email = reader.GetString("email");
                string address = reader.GetString("address");
                int status = reader.GetInt32("status");
                Teacher teacher = new Teacher();
                teacher.Id = id;
                teacher.FirstName = firstName;
                teacher.LastName = lastName;
                teacher.Email = email;
                teacher.Address = address;
                teacher.Status = status;
                list.Add(teacher);
            }

            return list;
        }

        public Teacher FindById(int id)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"select * from teachers where id = {id}", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Teacher t = new Teacher();
                t.Id = reader.GetInt32("id");
                t.FirstName = reader.GetString("firstName");
                t.LastName = reader.GetString("lastName");
                t.Email = reader.GetString("email");
                t.Address = reader.GetString("address");
                t.Status = reader.GetInt32("status");
                return t;
            }

            return null;
        }

        public bool Update(int id, Teacher updateTeacher)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(
                $"update teachers set `firstname` = '{updateTeacher.FirstName}',`lastname`='{updateTeacher.LastName}',`email`='{updateTeacher.Email}',`address`='{updateTeacher.Address}',`status`='{updateTeacher.Status}' where `id`={id}",
                connection);
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }

        public bool Delete(int id)
        {
            MySqlConnection connection =
                new MySqlConnection(
                    $"Server={SeverName}; database={DatabaseName}; UID={Uid}; password={Password}; persistsecurityinfo={PersistSecurityInfo};port={SeverPort};SslMode={SslMode}");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"delete from teachers where `id`={id}", connection);
            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
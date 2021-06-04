namespace ConsoleApplication3
{
    public class Teacher
    {
        public Teacher(int id, string lastName, string firstName, string email, string address, int status)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Address = address;
            Status = status;
        }

        public Teacher()
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
    }
}
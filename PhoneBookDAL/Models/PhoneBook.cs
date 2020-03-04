namespace PhoneBookDAL.Models
{
    public class PhoneBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}

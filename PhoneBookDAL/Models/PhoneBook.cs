using System.ComponentModel.DataAnnotations;

namespace PhoneBookDAL.Models
{
    public class PhoneBook
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public PhoneType PhoneType { get; set; }

    }
}

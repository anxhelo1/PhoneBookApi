using System.Collections.Generic;
using PhoneBookDAL.Models;

namespace PhoneBookDAL.Repository
{
    public interface IPhoneBookRepository
    {
        List<PhoneBook> GetPhoneBooks();
        void SavePhoneBooks(List<PhoneBook> phoneBooks);
    }
}

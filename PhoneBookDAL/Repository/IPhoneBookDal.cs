using System.Collections.Generic;
using PhoneBookDAL.Models;

namespace PhoneBookDAL.Repository
{
    public interface IPhoneBookDal
    {
        List<PhoneBook> GetPhoneBooks();
        void SavePhoneBooks(List<PhoneBook> phoneBooks);
    }
}

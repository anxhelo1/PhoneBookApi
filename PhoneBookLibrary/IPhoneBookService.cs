using PhoneBookDAL.Models;
using System.Collections.Generic;

namespace PhoneBookLibrary
{
    public interface IPhoneBookService
    {
        void Create(PhoneBook phoneBook);
        List<PhoneBook> GetAll();
        PhoneBook Get(int id);
        void Delete(int id);
    }
}

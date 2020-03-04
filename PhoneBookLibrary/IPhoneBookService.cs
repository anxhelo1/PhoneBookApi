using System;
using System.Collections.Generic;
using System.Text;
using PhoneBookDAL.Models;

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

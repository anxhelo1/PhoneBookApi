using System;
using System.Collections.Generic;
using PhoneBookLibrary;


namespace PhoneBookDAL
{
    public interface IPhoneBookDal
    {
        List<PhoneBook> GetPhoneBooks();
        void SavePhoneBooks(List<PhoneBook> phoneBooks);
    }
}

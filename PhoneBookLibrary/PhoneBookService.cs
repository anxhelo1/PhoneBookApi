using PhoneBookDAL.Models;
using PhoneBookDAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookLibrary
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly List<PhoneBook> _list;
        private readonly IPhoneBookRepository _phoneBookDal;

        public PhoneBookService(IPhoneBookRepository iPhoneBookDal)
        {
            _phoneBookDal = iPhoneBookDal;
            _list = _phoneBookDal.GetPhoneBooks();
        }
        public void Create(PhoneBook phoneBook)
        {

            var id = _list.Any() ? _list.Max(x => x.Id) + 1 : 1;
            phoneBook.Id = id;

            _list.Add(phoneBook);
            _phoneBookDal.SavePhoneBooks(_list);
        }

        public List<PhoneBook> GetAll()
        {
            return _list;
        }

        public PhoneBook Get(int id)
        {
            return _list.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var el = _list.SingleOrDefault(x => x.Id == id);

            _list.Remove(el);
            _phoneBookDal.SavePhoneBooks(_list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PhoneBookLibrary;

namespace PhoneBookDAL
{
    public class PhoneBookDal : IPhoneBookDal
    {
        private string _file;

        public PhoneBookDal(string file)
        {
            _file = file;
        }
       
        public List<PhoneBook> GetPhoneBooks()
        {
            using (var r = new StreamReader(_file))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<PhoneBook>>(json);
            }
        }
        public void SavePhoneBooks(List<PhoneBook> phoneBooks)
        {
            using (var file = File.CreateText(_file))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, phoneBooks);
            }
        }
    }
}

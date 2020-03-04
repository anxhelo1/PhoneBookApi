using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PhoneBookDAL.Models;

namespace PhoneBookDAL.Repository
{
    public class JsonPhoneBookRepository : IPhoneBookRepository
    {
        private readonly string _file;

        public JsonPhoneBookRepository(string file)
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

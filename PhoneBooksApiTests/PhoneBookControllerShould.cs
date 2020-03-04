using System.Collections.Generic;
using System.Linq;
using BookWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PhoneBookDAL.Models;
using PhoneBookLibrary;

namespace PhoneBooksApiTests
{
    [TestFixture]
    public class PhoneBookControllerShould
    {
        private List<PhoneBook> _list;

        [SetUp]
        public void Setup()
        {
            _list = new List<PhoneBook> { new PhoneBook
            {
                Id = 1,
                Name = It.IsAny<string>(),
                Lastname = It.IsAny<string>(),
                Number = It.IsAny<string>(),
                PhoneType = It.IsAny<PhoneType>()
            }, new PhoneBook
            {
                Id = 2,
                Name = It.IsAny<string>(),
                Lastname = It.IsAny<string>(),
                Number = It.IsAny<string>(),
                PhoneType = It.IsAny<PhoneType>()
            } };
        }

        [Test]
        public void ReturnListOfBooks()
        {
            var mockedBookService = new Mock<IPhoneBookService>();

            mockedBookService.Setup(x => x.GetAll()).Returns(_list);

            var sut = new PhoneBookController(mockedBookService.Object);

            var result = sut.GetPhoneBooks().Result as OkObjectResult;

            var items = result?.Value as List<PhoneBook>;
           
           Assert.That(items?.Count, Is.EqualTo(_list.Count));
           Assert.That(items?.First().Id, Is.EqualTo(_list.First().Id));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(-1, null)]
        public void ReturnPhoneBook(int id, int? returnedPhoneBookId)
        {
            var mockedBookService = new Mock<IPhoneBookService>();

            mockedBookService.Setup(x => x.Get(id)).Returns(_list.Find(x => x.Id == id));

            var sut = new PhoneBookController(mockedBookService.Object);

            var result = sut.GetPhoneBook(id).Result as OkObjectResult;

            var item = result?.Value as PhoneBook;

            Assert.That(item?.Id, Is.EqualTo(returnedPhoneBookId));
        }
    }
}

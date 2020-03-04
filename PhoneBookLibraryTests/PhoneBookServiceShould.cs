using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PhoneBookLibrary;
using Moq;
using PhoneBookDAL;

namespace PhoneBookLibraryTests
{
    [TestFixture]
    class PhoneBookServiceShould
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
        public void ReturnTheListOfPhoneBooks()
        {
           
            var mockedPhoneBookDal = new Mock<IPhoneBookDal>();
            mockedPhoneBookDal.Setup(x => x.GetPhoneBooks())
                .Returns(_list);

            var sut = new PhoneBookService(mockedPhoneBookDal.Object);
            var result = sut.GetAll();

            Assert.That(result.Count, Is.EqualTo(_list.Count));
        }

        [Test]
        public void AddPhoneBookToList()
        {

            var mockedPhoneBookDal = new Mock<IPhoneBookDal>();
            var phoneBook = new PhoneBook();
            mockedPhoneBookDal.Setup(x => x.GetPhoneBooks())
                .Returns(_list);

            mockedPhoneBookDal.Setup(x => x.SavePhoneBooks(_list));

            var sut = new PhoneBookService(mockedPhoneBookDal.Object);
            sut.Create(phoneBook);

            Assert.That(sut.GetAll().Last().Id, Is.EqualTo(3));
        }

        [Test]
        public void AddFirstPhoneBookWithId1()
        {

            var mockedPhoneBookDal = new Mock<IPhoneBookDal>();
            var phoneBook = new PhoneBook();
            mockedPhoneBookDal.Setup(x => x.GetPhoneBooks())
                .Returns(new List<PhoneBook>());

            mockedPhoneBookDal.Setup(x => x.SavePhoneBooks(_list));

            var sut = new PhoneBookService(mockedPhoneBookDal.Object);
            sut.Create(phoneBook);

            Assert.That(sut.GetAll().First().Id, Is.EqualTo(1));
        }

        [Test]
        public void RemovesPhoneBook()
        {

            var mockedPhoneBookDal = new Mock<IPhoneBookDal>();
            mockedPhoneBookDal.Setup(x => x.GetPhoneBooks())
                .Returns(_list);
            mockedPhoneBookDal.Setup(x => x.SavePhoneBooks(_list));

            var sut = new PhoneBookService(mockedPhoneBookDal.Object);
            sut.Delete(_list.First().Id);

            Assert.That(sut.GetAll().Count, Is.EqualTo(1));
        }
    }
}

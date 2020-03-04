using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookDAL.Models;
using PhoneBookLibrary;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [HttpGet("")]
        public ActionResult GetPhoneBooks()
        {
            return Ok(_phoneBookService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetPhoneBook(int id)
        {
            var phoneBook = _phoneBookService.Get(id);

            if (phoneBook == null)
            {
                return NotFound();
            }
            return Ok(phoneBook);
        }

        [HttpPost("")]
        public ActionResult AddPhoneBook(PhoneBook phoneBook)
        {

             _phoneBookService.Create(phoneBook);
             return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult RemovePhoneBook(int id)
        {
            var phoneBook = _phoneBookService.Get(id);

            if (phoneBook == null)
            {
                return NotFound();
            }

            _phoneBookService.Delete(id);

            return NoContent();
        }
    }
}
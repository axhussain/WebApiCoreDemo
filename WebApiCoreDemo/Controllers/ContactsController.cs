using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreDemo.Data;
using WebApiCoreDemo.Data.Entities;

namespace WebApiCoreDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IWebApiRepository _webApiRepository;

        public ContactsController(IWebApiRepository webApiRepository)
        {
            _webApiRepository = webApiRepository;
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return _webApiRepository.GetAllContacts();
        }

        //TODO: Fix this
        //[HttpGet]
        //public IEnumerable<Contact> Get([FromQuery]int count)
        //{
        //    return _webApiRepository.GetContacts(count);
        //}

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(int id)
        {
            var contact = _webApiRepository.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return new ObjectResult(contact);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Contact contact)
        {
            if (contact == null)
            {
                BadRequest();
            }

            _webApiRepository.AddContact(contact);
            return CreatedAtRoute("GetContact", new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Contact contact)
        {
            if (contact == null || contact.Id != id)
            {
                return BadRequest();
            }
            
            var person = _webApiRepository.GetContact(id);
            if (person == null)
            {
                return NotFound();
            }

            _webApiRepository.UpdateContact(contact);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _webApiRepository.GetContact(id);
            if (person == null)
            {
                return NotFound();
            }
            _webApiRepository.DeleteContact(id);
            return new NoContentResult();
        }
    }
}

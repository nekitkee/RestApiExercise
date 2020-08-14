using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using ContactManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        [HttpGet]
        [Route("{id?}")]
        public List<Contact> Get([FromRoute]int? id)
        {
            if (id!=null)
            {
                return new List<Contact>() { contactRepository.GetById(id.Value) };
            }

           
            return contactRepository.GetAllContacts();
        }


        [HttpPost]
        
        public IActionResult AddContact([FromBody]Contact contact)
        {
           if(contactRepository.SaveContact(contact))
           {
                return this.Ok();
           }

            return this.UnprocessableEntity();

        } 
       




    }
}

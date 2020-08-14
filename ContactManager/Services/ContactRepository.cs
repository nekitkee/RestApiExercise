using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public class ContactRepository
    {

        private const string databaseFileName = "database.json";


        public Contact GetById(int id)
        {

            return this.GetAllContacts().Find(x => x.Id == id);
        }


        public List<Contact> GetAllContacts()
        {

            string jsonData = System.IO.File.ReadAllText(databaseFileName);
            return string.IsNullOrEmpty(jsonData) ? new List<Contact>() : 
                JsonSerializer.Deserialize<List<Contact>>(jsonData);

        }

        public bool SaveContact(Contact contact)
        {
            try
            {
                List<Contact> contacts = GetAllContacts();
                contacts.Add(contact);
                System.IO.File.WriteAllText(databaseFileName, JsonSerializer.Serialize(contacts));
                return true;
            }
            catch 
            {
                return false;
            }
        }



        public List<Contact> GetAllContactsOld()
        {
            return new List<Contact>
            {
                new Contact
                {
                    Id=1,
                    Name="Glen Block"
                } ,
                new Contact{
                    Id=2,
                    Name = "Dan Roth"
                }
            };
        }

    }
}

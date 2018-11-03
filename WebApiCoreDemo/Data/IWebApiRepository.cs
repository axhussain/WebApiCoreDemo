using System.Collections.Generic;
using WebApiCoreDemo.Data.Entities;

namespace WebApiCoreDemo.Data
{
    public interface IWebApiRepository
    {
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Contact> GetContacts(int count);
        Contact GetContact(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}
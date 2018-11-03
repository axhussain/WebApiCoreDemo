using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCoreDemo.Data.Entities;

namespace WebApiCoreDemo.Data
{
    public class WebApiRepository : IWebApiRepository
    {
        private readonly WebApiDbContext _ctx;

        public WebApiRepository(WebApiDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _ctx.Contacts.AsNoTracking().ToList();
        }

        public IEnumerable<Contact> GetContacts(int count)
        {
            return _ctx.Contacts.AsNoTracking().Take(count).ToList();
        }

        public Contact GetContact(int id)
        {
            return _ctx.Contacts.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            _ctx.Contacts.Add(contact);
            _ctx.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            _ctx.Entry(contact).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var person = _ctx.Contacts.Find(id);
            _ctx.Contacts.Remove(person);
            _ctx.SaveChanges();
        }
    }
}

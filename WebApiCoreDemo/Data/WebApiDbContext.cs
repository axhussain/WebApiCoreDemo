﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCoreDemo.Data.Entities;

namespace WebApiCoreDemo.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

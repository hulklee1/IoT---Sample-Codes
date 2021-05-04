using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class userInfo : DbContext
    {
        public userInfo() : base(@"Data Source=192.168.0.80;Initial Catalog=kostaDB;Persist Security Info=True;User ID='kosta';Password='kosta'") { }
        public DbSet<user> users { get; set; }
    }
}
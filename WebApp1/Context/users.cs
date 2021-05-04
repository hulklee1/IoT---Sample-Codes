using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class userInfo : DbContext   // Table 명과 같은 클래스 명을 사용하지 말 것
    {
        public userInfo() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\source\repos\MyDatabase.mdf;Integrated Security=True;Connect Timeout=30") 
        { }

        public DbSet<user> customer { get; set; }
    }
}
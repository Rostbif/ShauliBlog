using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShauliBlogMvc.Models
{
    public class Fan
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Seniority { get; set; }
    }

    public class FanDbContext : DbContext
    {
        public DbSet<Fan> Fans { get; set; }
    }
}
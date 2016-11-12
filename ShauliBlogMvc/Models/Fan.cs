using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShauliBlogMvc.Models
{
    public class Fan
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Sex { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public int Seniority { get; set; }
        public string Address { get; set; }
        public string Site { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.proj0
{
    public class Person
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public List<Person> Friends { get; set; }
        public Person() { }
    }
}
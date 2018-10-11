using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.proj0
{
    public class Pet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int[] InList { get; set; }
        public Person Owner { get; set; }
        public Pet() { }
    }
}
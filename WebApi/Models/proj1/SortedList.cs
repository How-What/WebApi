using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.proj1
{
    public class SortedList
    {
        public int[] OutList { get; set; }
        public string Algorithm { get; set; }
        public string Time { get; set; }

        public SortedList() { }
    }
}
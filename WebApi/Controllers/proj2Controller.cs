using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;
using WebApi.Models.proj2;
using WebApi.OtherClasses.proj2;
using Queue = WebApi.Models.proj2.Queue;

namespace WebApi.Controllers
{
    public class proj2Controller : ApiController
    {
        // GET: /proj2
        [HttpGet]
        public IHttpActionResult Index()
        {
            SortedDictionary<int, string> dictionary = new SortedDictionary<int, string>();
            dictionary.Add(12, "qew");
            dictionary.Add(1, "LOL");
            dictionary.Add(12, "qew");
            dictionary.Add(3, "pew");
            return Ok(dictionary);
            //return Ok("Wallace Wong, Programming Project 2"); //Returns response 200: Ok
        }

        // POST: /proj2
        [HttpPost]
        public IHttpActionResult Index(HttpRequestMessage request)
        {
            // Variables 
            var jsonstring = request.Content.ReadAsStringAsync().Result; //takes json post request var will be string

            // Checks For POST
            if (ModelState.IsValid)
            {
                if (jsonstring == null)
                {
                    return Ok("Error: No input Given");
                }
                else
                {
                    // Main code goes Here'
                    PriorityQueue pq = new PriorityQueue();
                    var settings = new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error
                    };

                    //return Ok("k");

                    try {
                        var myObject = JsonConvert.DeserializeObject<ListIn>(jsonstring, settings);
                        var inlist = myObject.InList;
                        foreach (var item in inlist) {
                            var subObjects = JsonConvert.DeserializeObject<Queue>(item.ToString(), settings);
                        }
                        return Ok("Hello");
                    }
                    catch {
                        return Ok("Error: Malforned Json");
                    }
                }
            }
            else
            {
                return Ok("Error: Request");
            }
        }
    }
}

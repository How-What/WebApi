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
            return Ok("Wallace Wong, Programming Project 2"); //Returns response 200: Ok
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
                    /* Main code goes Here*/
                    //Create an instance of Priority Queue
                    PriorityQueue pq = new PriorityQueue();

                    // Json serializer settings
                    var settings = new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error
                    };

                    try {

                        var myObject = JsonConvert.DeserializeObject<ListIn>(jsonstring, settings);
                        var inlist = myObject.InList;

                        //cmd cases assumes there are ony enqueue and dequeue
                        foreach (var item in inlist) {
                            switch (item.cmd.ToLower()) {
                                case "enqueue":
                                    pq.Enqueue(int.Parse(item.pri), item.name);
                                    break;
                                case "dequeue":
                                    pq.Dequeue();
                                    break;
                                default:
                                    return Ok(String.Format("No such command named: {0}", item.cmd));

                            }
                        }

                        //return in json format;
                        ListOut outlist = new ListOut
                        {
                            OutList = pq.Walk().ToArray()
                        };
                        return Ok(outlist);
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

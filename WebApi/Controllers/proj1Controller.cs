using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;
using WebApi.Models.proj0;
using WebApi.Models.proj1;
using WebApi.OtherClasses.proj1;

namespace WebApi.Controllers
{
    public class proj1Controller : ApiController
    {
        // GET: /proj1
        [HttpGet]
        public IHttpActionResult Index()
        {
            int a = -3;
            int b = 2;
            if (a > b)
            {
                return Ok("Hello world");
            }
            else
            {
                return Ok("Wallace Wong, Programming Project 1"); //Returns response 200: Ok
            }
           
        }

        // POST: /proj1
        [HttpPost]
        public IHttpActionResult Index(HttpRequestMessage request)
        {
            // Variables 
            var jsonstring = request.Content.ReadAsStringAsync().Result; //takes json post request var will be string

            // Checks For POST
            if (ModelState.IsValid)
            {
                if(jsonstring == null)
                {
                    return Ok("Error: No input Given");
                }
                else
                {
                    // Main code goes Here'
                    var settings = new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error
                    };
                    try
                    {
                        var myObject = JsonConvert.DeserializeObject<ListIn>(jsonstring);
                        var inlist = myObject.InList;

                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        var outlist = InsSort.InsertionSort(inlist);
                        timer.Stop();
                        TimeSpan ts = timer.Elapsed;

                        SortedList sorted = new SortedList
                        {
                            OutList = outlist,
                            Algorithm = "Inserstion Sort",
                            Time = String.Format("{0}Ms", ts.TotalMilliseconds)
                        };

                        return Ok(sorted);
                    }
                    catch
                    {
                        return Ok("Error: Invalid Input; Is the Json correct?");
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

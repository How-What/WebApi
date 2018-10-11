using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.proj0;

namespace WebApi.Controllers
{
    public class proj0Controller : ApiController
    {
        // GET: proj0
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("Hello");
        }

        // POST: proj0
        [HttpPost]
        public IHttpActionResult Index(HttpRequestMessage request)
        {
            var jsonstr = request.Content.ReadAsStringAsync().Result;
            //string jsonstring = "{ \"name\" : \"Fido\", \"lastname\" : \"Dog\" }";
            if (ModelState.IsValid)
            {
                if (jsonstr == null)
                {
                    return Ok(jsonstr);
                }
                else
                {
                    try
                    {
                        var settings = new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Error
                        };
                        var myObject = JsonConvert.DeserializeObject<Pet>(jsonstr, settings);
                        return Ok("Hello");
                    }
                    catch
                    {
                        return Ok("Error, Invalid json input.");
                    }
                }
            }
            else
            {
                return Ok("Error in rquests");
            }
        }
    }
}

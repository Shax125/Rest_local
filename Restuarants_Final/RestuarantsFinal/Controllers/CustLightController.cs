using RestuarantsFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestuarantsFinal.Controllers
{
    public class CustLightController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(int id)
        {
            {
                CustomerHL c = new CustomerHL();
                c.setDefaultPerfernces(id);

            }
        }

        // PUT api/<controller>/5
        public void Put(int id, string arr) 
        {
            CustomerHL ch = new CustomerHL();
            ch.updatePrefernces(id, arr);
        }
        
        

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
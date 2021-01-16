using RestuarantsFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestuarantsFinal.Controllers
{
    public class CustomerController : ApiController
    {

        public List <Customer> Get(string mail, string password)
        {
            Customer C = new Customer();
            List<Customer> uList = C.getUserStatus(mail, password);
            return uList;
        }


        // POST api/<controller>
        public int Post([FromBody] Customer cust)
        {
           return cust.InsertCust();


        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
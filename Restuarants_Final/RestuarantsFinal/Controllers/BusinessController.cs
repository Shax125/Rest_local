using RestuarantsFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestuarantsFinal.Controllers
{
    public class BusinessController : ApiController
    {
        // GET api/<controller>


        //organic without prefernces
        public List<Business> Get(string categoryfromuser)
        {
            Business r = new Business();
            List<Business> rList = r.getRestaurants(categoryfromuser);
            return rList;
        }

        //funded without prefernces
        public List<Business> GetFunded(string categoryFund)
        {
            Business r = new Business();
            List<Business> rList = r.GetFunded(categoryFund);
            return rList;
        }



        //organic with prefernces

        public List<Business> GetPrefer(string categoryPrefer, int id)
        {
            Business r = new Business();
            List<Business> rList = r.GetPrefer(categoryPrefer, id);
            return rList;
        }


        //funded with prefernces

        public List<Business> GetPreferFund(string categoryPreferFund, int id)
        {
            Business r = new Business();
            List<Business> rList = r.GetPreferfund(categoryPreferFund, id);
            return rList;
        }

        public List<Business> Get()
        {
            Business r = new Business();
            List<Business> rList = r.getRestaurantsWithoutCampaign();
            return rList;
        }



        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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
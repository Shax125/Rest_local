using RestuarantsFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestuarantsFinal.Controllers
{
    public class CampaignController : ApiController
    {

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int Post([FromBody] Campaign cmp)
        {
            return cmp.InsertCampaign();
        }
    


        // PUT api/<controller>/5
        public void Put(int id)
        {
            Campaign c = new Campaign();
            c.setNotactive(id);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }


        public List<Campaign> Get()
        {
            Campaign c = new Campaign();
            List<Campaign> cList = c.getcampains();
            return cList;
        }

        public void Put(int id, int newbadget)
        {
            Campaign c = new Campaign();
            c.setbadget(id, newbadget);

        }

    
    }
}
using RestuarantsFinal.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestuarantsFinal.Models
{
    public class CustomerHL
    {
        int id;
        int preferID;

        public CustomerHL(int id, int preferID)
        {
            Id = id;
            PreferID = preferID;
        }

        public int Id { get => id; set => id = value; }
        public int PreferID { get => preferID; set => preferID = value; }


        public CustomerHL()
        {

        }

        public void InsertCust()
        {
            DBService dbs = new DBService();
            dbs.InsertCustomerCH(this);

        }


    }
}
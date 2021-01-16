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
        bool status;

        public CustomerHL(int id, int preferID, bool status)
        {
            Id = id;
            PreferID = preferID;
            Status = status;
        }

        public int Id { get => id; set => id = value; }
        public int PreferID { get => preferID; set => preferID = value; }
        public bool Status { get => status; set => status = value; }


        public CustomerHL()
        {

        }

        public void setDefaultPerfernces(int id)
        {
            DBService dbs = new DBService();
            dbs.setDefaultPerfernces(id);

        }

        public void updatePrefernces(int id, string arr)
        {
            DBService dbs = new DBService();
            dbs.updatePrefernces(id, arr);




        }


    }
}
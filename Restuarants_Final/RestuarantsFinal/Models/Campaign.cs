using RestuarantsFinal.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestuarantsFinal.Models
{
    public class Campaign
    {
        int id;
        int budjet;
        float balance;
        int clickcounter;
        int viewcounter;
        string status;
        int idR;

        public Campaign(int id, int budjet, float balance, int clickcounter, int viewcounter, string status, int idR)
        {
            Id = id;
            Budjet = budjet;
            Balance = balance;
            Clickcounter = clickcounter;
            Viewcounter = viewcounter;
            Status = status;
            IdR = idR;
        }

        public Campaign()
        {

        }

        public int Id { get => id; set => id = value; }
        public int Budjet { get => budjet; set => budjet = value; }
        public float Balance { get => balance; set => balance = value; }
        public int Clickcounter { get => clickcounter; set => clickcounter = value; }
        public int Viewcounter { get => viewcounter; set => viewcounter = value; }
        public string Status { get => status; set => status = value; }

        public int IdR { get => idR; set => idR = value; }

        public List<Campaign> getcampains()
        {
            DBService dbs = new DBService();
            List<Campaign> cList = dbs.getcampains();
            return cList;
        }


        public void setNotactive(int id)
        {
            DBService dbs = new DBService();
            dbs.setNotactive(id);
        }


        //for update counter view and balance
        public void SetViewCounterAndBalance(int id)
        {
            DBService dbs = new DBService();
            dbs.SetViewCounterAndBalance(id);
        }

        public int InsertCampaign() //he want to enter himself so no need to pass
        {
            DBService dbs = new DBService(); //so we can use the function there
            return dbs.InsertCampaign(this);
        }

        public void setbadget(int id, int newbadget)
        {
            DBService dbs = new DBService();
            dbs.setbadget(id, newbadget);
        }


        //click counter


        public void PutClickCounter(int id)
        {
            DBService dbs = new DBService();
            dbs.PutClickCounter(id);
        }





    }
    



}
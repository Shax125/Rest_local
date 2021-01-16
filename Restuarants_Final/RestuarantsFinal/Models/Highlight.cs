using RestuarantsFinal.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestuarantsFinal.Models
{
    public class Highlight
    {

        int id;
        string highlightName;

        public Highlight(int id, string highlightName)
        {
            Id = id;
            HighlightName = highlightName;
        }

        public Highlight()
        {

        }

        public int Id { get => id; set => id = value; }
        public string HighlightName { get => highlightName; set => highlightName = value; }

        

       public List<Highlight> getHighlights()
        {
            DBService dbs = new DBService();
            List<Highlight> hList = dbs.getHighlights();
            return hList;
        }



    }
}
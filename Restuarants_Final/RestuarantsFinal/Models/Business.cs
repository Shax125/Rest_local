using RestuarantsFinal.Models.DAL;
using System.Collections.Generic;

namespace RestuarantsFinal.Models
{
    public class Business
    {
        int id;
        string name;
        string img;
        float rating;
        string category;
        string address;
        string phone;
        int priceRange;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Img { get => img; set => img = value; }
        public float Rating { get => rating; set => rating = value; }
        public string Category { get => category; set => category = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int PriceRange { get => priceRange; set => priceRange = value; }


        public Business(int id, string name, string img, float rating, string category, string address, string phone, int priceRange)
        {
            Id = id;
            Name = name;
            Img = img;
            Rating = rating;
            Category = category;
            Address = address;
            Phone = phone;
            PriceRange = priceRange;
        }

        public Business()
        {

        }


        //organic without prefernces
        public List<Business> getRestaurants(string categoryfromuser)
        {
            DBService dbs = new DBService();
            List<Business> RList = dbs.getRestaurants(categoryfromuser);
            return RList;
        }

        //founded without preferences
        public List<Business> GetFunded(string categoryFund)
        {
            DBService dbs = new DBService();
            List<Business> RList = dbs.GetFunded(categoryFund);
            return RList;
        }





        //organic with prefernces
        public List<Business> GetPrefer(string categoryPrefer, int id)
        {
            DBService dbs = new DBService();
            List<Business> RList = dbs.getRestaurantsPrfer(categoryPrefer, id);
            return RList;
        }


        //funded with preferences
        public List<Business> GetPreferfund(string categoryPreferFund, int id)
        {
            DBService dbs = new DBService();
            List<Business> RList = dbs.GetPreferfund(categoryPreferFund, id);
            return RList;
        }




        public List<Business> getRestaurantsWithoutCampaign()
        {
            DBService dbs = new DBService();
            List<Business> RList = dbs.getRestaurantsWithoutCampaign();
            return RList;
        }


    }
}
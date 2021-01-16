﻿using RestuarantsFinal.Models.DAL;
using System.Collections.Generic;

namespace RestuarantsFinal.Models
{
    public class Business
    {
        string name;
        string img;
        float rating;
        string category;
        string address;
        string phone;
        int priceRange;

        public string Name { get => name; set => name = value; }
        public string Img { get => img; set => img = value; }
        public float Rating { get => rating; set => rating = value; }
        public string Category { get => category; set => category = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int PriceRange { get => priceRange; set => priceRange = value; }


        public Business(string name, string img, float rating, string category, string address, string phone, int priceRange)
        {
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

        public List<Business> getRestaurants(string categoryfromuser)
        {
            DBService dbs = new DBService();
            List<Business> RList = dbs.getRestaurants(categoryfromuser);
            return RList;
        }


    }
}
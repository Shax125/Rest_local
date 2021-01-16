using RestuarantsFinal.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestuarantsFinal.Models
{
    public class Customer
    {

        int id;
        string fname;
        string lname;
        string email;
        string phone;
        string pass;
        int range;
        string img;
        
        


        public Customer(int id, string fname, string lname, string email, string phone, string pass, int range,  string img)
        {
            Id= id;
            Fname = fname;
            Lname = lname;
            Email = email;
            Phone = phone;
            Pass = pass;
            Range = range;
            Img = img;
            

        }


        public int Id { get => id; set => id = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Range { get => range; set => range = value; }
        public string Img { get => img; set => img = value; }

        

        public Customer()
        {

        }

        public List<Customer> getUserStatus(string mail, string password)
        {
            DBService dbs = new DBService();
            List<Customer> uList = dbs.getUserStatus(mail, password);
            return uList;
        }


        public int InsertCust() //he want to enter himself so no need to pass
        {
            DBService dbs = new DBService(); //so we can use the function there
            return dbs.InsertCustomer(this);

            // return dbs.InsertCustomer(this);
        }


    }
}
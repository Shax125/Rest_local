using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace RestuarantsFinal.Models.DAL
{
    public class DBService
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBService()
        {

        }

        public SqlConnection connect(String conString)  //The first C
        {
            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        
        public List<Customer> getUserStatus(string mail, string password)
        {
            SqlConnection con = null;
            List<Customer> uList = new List<Customer>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Customers_2021A_T4 WHERE Customers_2021A_T4.email = '" + mail + "' AND Customers_2021A_T4.pass_word = '" + password + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                
                while (dr.Read())
                {   // Read till the end of the data into a row
                    Customer c = new Customer();
                    
                    c.Fname = (string)dr["first_name"];
                    c.Lname = (string)dr["last_name"];
                    c.Email = (string)dr["email"];
                    c.Id =     Convert.ToInt32(dr["id"]);
                    uList.Add(c);
                }

                return uList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        
            public List<Highlight> getHighlights()
        {
            SqlConnection con = null;
            List<Highlight> hList = new List<Highlight>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Highlights_2021A_T4"; 
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Highlight h = new Highlight();

                    h.Id = Convert.ToInt32(dr["id"]);
                    h.HighlightName = (string)dr["highlight"];
                  
                    hList.Add(h);
                }

                return hList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }
        public List<Business> getRestaurants(string categoryfromuser)
        {
            SqlConnection con = null;
            List<Business> rList = new List<Business>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Restaurants_2021A_T4 Order By Restaurants_2021A_T4.price_range"; //WHERE Customers_2021A_T4.email = '" + mail + "' AND Customers_2021A_T4.pass_word = '" + password + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Business r = new Business();
                    r.Name = (string)dr["name"];
                    r.Img = (string)dr["img"];
                    r.Rating = (float)Convert.ToDouble(dr["rating"]);
                    r.Category = (string)dr["category"];
                    r.Address = (string)dr["address"];
                    r.Phone = (string)dr["phone"];
                    r.PriceRange = Convert.ToInt32(dr["price_range"]);

                    if(r.Category.Contains(categoryfromuser))
                        rList.Add(r);

                }

                return rList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public List<Campaign> getcampains()
        {
            SqlConnection con = null;
            List<Campaign> cList = new List<Campaign>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Campaign_2021A_T4 "; //WHERE Customers_2021A_T4.email = '" + mail + "' AND Customers_2021A_T4.pass_word = '" + password + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Campaign c = new Campaign();
                    c.Id = Convert.ToInt32(dr["id"]);
                    c.Budjet = Convert.ToInt32( dr["budget"]);
                    c.Balance = Convert.ToInt32(dr["balance"]);
                    c.Clickcounter = Convert.ToInt32(dr["clickCounter"]);
                    c.Viewcounter = Convert.ToInt32(dr["viewCounter"]);
                    c.Status = (string)dr["status"];
                    c.IdR = Convert.ToInt32(dr["idR"]);
                    if (c.Status == "Active")
                    cList.Add(c);


                }

                return cList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public int setNotactive(int id)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("Igroup44DB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(id);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected; //return how many row's effected.
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();

                }
            }

        }
        private String BuildInsertCommand(int id) //The second C
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            //sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", business.Id, business.Name, business.Img, business.Rating, business.Category, business.Address, business.Phone, business.PriceRange);
            String prefix = "UPDATE Campaign_2021A_T4 SET Status = 'NotActive' WHERE id= "+ id;
            command = prefix;

            return command;
        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

        public int InsertCustomer(Customer bs)
        {

            SqlConnection con2;
            SqlCommand cmd2;

            try
            {
                con2 = connect("Igroup44DB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(bs);      // helper method to build the insert string

            cmd2 = CreateCommand2(cStr, con2);             // create the command

            try
            {
                int numEffected = cmd2.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
                //throw new Exception("same primary key");
            }

            finally
            {
                if (con2 != null)
                {
                    // close the db connection
                    con2.Close();
                }
            }

        }

        private String BuildInsertCommand(Customer bs)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values( '{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}')", bs.Fname, bs.Lname, bs.Email, bs.Phone, bs.Pass, bs.Range, bs.Img );
            String prefix = "INSERT INTO Customers_2021A_T4 " + "( [first_name], [last_name], [email], [phone], [pass_word],[price_range], [photo]) ";
            command = prefix + sb.ToString();

            return command;
        }

        private SqlCommand CreateCommand2(String CommandSTR, SqlConnection con2)
        {

            SqlCommand cmd2 = new SqlCommand(); // create the command object

            cmd2.Connection = con2;              // assign the connection to the command object

            cmd2.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd2.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd2.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd2;
        }

        public int InsertCustomerCH(CustomerHL bs)
        {

            SqlConnection con3;
            SqlCommand cmd3;

            try
            {
                con3 = connect("Igroup44DB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(bs);      // helper method to build the insert string

            cmd3 = CreateCommand3(cStr, con3);             // create the command

            try
            {
                int numEffected = cmd3.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
                //throw new Exception("same primary key");
            }

            finally
            {
                if (con3 != null)
                {
                    // close the db connection
                    con3.Close();
                }
            }

        }

        private String BuildInsertCommand(CustomerHL bs)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values( '{0}', '{1}')", bs.Id, bs.PreferID);
            String prefix = "INSERT INTO Customer_Highlights_2021A_T4 " + "( [idC], [idH]) ";
            command = prefix + sb.ToString();

            return command;
        }

        private SqlCommand CreateCommand3(String CommandSTR, SqlConnection con3)
        {

            SqlCommand cmd3 = new SqlCommand(); // create the command object

            cmd3.Connection = con3;              // assign the connection to the command object

            cmd3.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd3.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd3.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd3;
        }
    }
}
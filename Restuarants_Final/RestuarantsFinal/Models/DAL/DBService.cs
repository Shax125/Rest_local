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

        //to organic without prefernces
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

        //To Funded without Preferences
        public List<Business> GetFunded(string categoryFund)
        {
            SqlConnection con = null;
            List<Business> rList = new List<Business>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select * from Restaurants_2021A_T4 R inner join Campaign_2021A_T4_1 C on R.id=c.idR where r.category LIKE '%"+ categoryFund + "%' and C.status='Active' and C.balance>0";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Business r = new Business();
                    r.Id= Convert.ToInt32(dr["id"]);
                    r.Name = (string)dr["name"];
                    r.Img = (string)dr["img"];
                    r.Rating = (float)Convert.ToDouble(dr["rating"]);
                    r.Category = (string)dr["category"];
                    r.Address = (string)dr["address"];
                    r.Phone = (string)dr["phone"];
                    r.PriceRange = Convert.ToInt32(dr["price_range"]);

                   
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

        //To organic !With! prefernces
        public List<Business> getRestaurantsPrfer(string categoryPrefer, int id)
        {
            SqlConnection con = null;
            List<Business> rList = new List<Business>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select distinct A.id, A.name, A.img, A.rating, A.category, A.address, A.phone, A.price_range from HighlightsInRestaurants as R inner join Customer_HighLights_2021A_T4 as C on C.idH = R.idH inner join  Restaurants_2021A_T4 as A on R.idR = A.id inner join Customers_2021A_T4 O on O.id=C.idC  where idC =" + id+" and C.status ="+ 1 + " and A.category LIKE '%"+ categoryPrefer + "%' and O.price_range>=A.price_range ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Business r = new Business();
                    r.Id= Convert.ToInt32(dr["id"]);
                    r.Name = (string)dr["name"];
                    r.Img = (string)dr["img"];
                    r.Rating = (float)Convert.ToDouble(dr["rating"]);
                    r.Category = (string)dr["category"];
                    r.Address = (string)dr["address"];
                    r.Phone = (string)dr["phone"];
                    r.PriceRange = Convert.ToInt32(dr["price_range"]);

                    if (r.Category.Contains(categoryPrefer))
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

        //Funded with preferences
        public List<Business> GetPreferfund(string categoryPreferFund, int id)
        {
            SqlConnection con = null;
            List<Business> rList = new List<Business>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                 String selectSTR = " select distinct A.id, A.name, A.img, A.rating, A.category, A.address, A.phone, A.price_range from HighlightsInRestaurants R inner join Customer_HighLights_2021A_T4 C on R.idH=C.idH inner join Restaurants_2021A_T4 A on R.idR=A.id inner join Campaign_2021A_T4_1 P on P.idR=R.idR  inner join Customers_2021A_T4 O on O.id=C.idC where A.category LIKE '%" + categoryPreferFund + "%' and C.idC="+id+" and C.status="+1+ " and P.status='Active' and O.price_range>=A.price_range    ";
                //String selectSTR = "select DISTINCT R.id  restaurants_id,C.idC customer_id, R.name restaurants_name from Restaurants_2021A_T4 R inner join HighlightsInRestaurants HR on R.id = HR.idR inner join Customer_HighLights_2021A_T4 C on c.status ="+ 1 + " and c.idH = HR.idH where C.idC ="+ id+ " and R.category LIKE '%"+ categoryPreferFund + "%' and exists( select* from Campaign_2021A_T4_1 CA where CA.idR= R.id and CA.status= 'Active')";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Business r = new Business();
                    r.Id = Convert.ToInt32(dr["id"]);
                    r.Name = (string)dr["name"];
                    r.Img = (string)dr["img"];
                    r.Rating = (float)Convert.ToDouble(dr["rating"]);
                    r.Category = (string)dr["category"];
                    r.Address = (string)dr["address"];
                    r.Phone = (string)dr["phone"];
                    r.PriceRange = Convert.ToInt32(dr["price_range"]);

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

                String selectSTR = "SELECT * FROM Campaign_2021A_T4_1 "; //WHERE Customers_2021A_T4.email = '" + mail + "' AND Customers_2021A_T4.pass_word = '" + password + "'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Campaign c = new Campaign();
                    c.Id = Convert.ToInt32(dr["id"]);
                    c.Budjet = Convert.ToInt32( dr["budget"]);
                    c.Balance = (float)Convert.ToDouble(dr["balance"]);
                    c.Clickcounter = Convert.ToInt32(dr["clickCounter"]);
                    c.Viewcounter = Convert.ToInt32(dr["viewCounter"]);
                    c.Status = (string)dr["status"];
                    c.IdR = Convert.ToInt32(dr["idR"]);
                    //if (c.Status == "Active")
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

        public List<Business> getRestaurantsWithoutCampaign()
        {
            SqlConnection con = null;
            List<Business> rList = new List<Business>();

            try
            {
                con = connect("Igroup44DB"); // create a connection to the database using the connection String defined in the web config file

                //Get all restaurants without campaign, (get only id).
                String selectSTR = "select r.id from Restaurants_2021A_T4 r where r.id not in (select a.idR from Campaign_2021A_T4_1 a) "; 
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Business r = new Business();
                    r.Id = Convert.ToInt32(dr["id"]);

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

        public int setNotactive(int id, string status)
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

            String cStr = BuildInsertCommand6(id, status);      // helper method to build the insert string

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

        private String BuildInsertCommand6(int id, string status) //The second C
        {
           
            if (status == "Active")
                 return ("UPDATE Campaign_2021A_T4_1 SET Status = 'NotActive' WHERE id= "+ id);
            else
                return ("UPDATE Campaign_2021A_T4_1 SET Status = 'Active' WHERE id= " + id);


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
                int numEffected = (Int32)cmd2.ExecuteScalar(); // execute the command
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
            String prefix = "INSERT INTO Customers_2021A_T4 " + "( [first_name], [last_name], [email], [phone], [pass_word],[price_range], [photo]) output Inserted.id ";
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

        public int setDefaultPerfernces(int id)
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

            String cStr = BuildInsertCommandforPrefernces(id);      // helper method to build the insert string

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
        // arr of prefernces
        private String BuildInsertCommandforPrefernces(int id)
        {
            String command;

            // use a string builder to create the dynamic string
            string st = "";

            for (int i = 1; i < 10; i++)
            {
                    st += " ( " + id + " , " + i + " , " + 1 + " ), ";
            }
            st += " ( " + id + " , " + 10 + " , " + 1 + " )";

            String prefix = " INSERT INTO Customer_Highlights_2021A_T4 " + "( [idC], [idH], [status] )  VALUES ";
            command = prefix + st;

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

        public int updatePrefernces(int id, string arr)
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

            String cStr = BuildInsertCommand(id, arr);      // helper method to build the insert string

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

        private String BuildInsertCommand(int id, string arr) //The second C
        {
            //String command;

            string str = "";
            //StringBuilder sb = new StringBuilder();

            for (int i = 1, j = 1 ; j < 11; j++ )
            {
                str += " UPDATE Customer_HighLights_2021A_T4 SET status = " + arr[i] + " WHERE idC = "+ id + " AND idH = " + (j) + " ";
                i += 2;
            }

            // use a string builder to create the dynamic string
            //sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", business.Id, business.Name, business.Img, business.Rating, business.Category, business.Address, business.Phone, business.PriceRange);
            //String prefix = "UPDATE Customer_HighLights_2021A_T4  SET ";
            

            //command = prefix;

            return str;
        }

        public int InsertCampaign(Campaign cmp)
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

            String cStr = BuildInsertCommandforInsertCampaign(cmp);      // helper method to build the insert string

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

        private String BuildInsertCommandforInsertCampaign(Campaign cmp)
        {
            String command;

            String prefix = " INSERT INTO Campaign_2021A_T4_1 " + "([budget], [balance], [clickCounter], [viewCounter], [status], [idR] )  VALUES (" + cmp.Budjet + "," + cmp.Budjet +  "," + 0 + "," + 0 + ", 'Active' , "  + cmp.IdR + " )" ;
            command = prefix;

            return command;
        }

        public int setbadget(int id, int newbadget)
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

            String cStr = BuildInsertCommand(id, newbadget);      // helper method to build the insert string

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

        private String BuildInsertCommand(int id, int newbadget) //The second C
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            //sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", business.Id, business.Name, business.Img, business.Rating, business.Category, business.Address, business.Phone, business.PriceRange);
            String prefix = "UPDATE Campaign_2021A_T4_1 SET budget ="+ newbadget+",balance="+ newbadget +"- 0.1*viewCounter WHERE id= " + id;
            command = prefix;

            return command;
        }

        //update views and balance
        public int SetViewCounterAndBalance(int id)
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

            String cStr = BuildInsertCommandUpdate(id);      // helper method to build the insert string

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

        private String BuildInsertCommandUpdate(int id) //The second C
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            //sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", business.Id, business.Name, business.Img, business.Rating, business.Category, business.Address, business.Phone, business.PriceRange);
            String prefix = "UPDATE Campaign_2021A_T4_1 SET viewCounter = viewCounter+1 , balance=balance-0.1 WHERE idR= " + id;
            command = prefix;

            return command;
        }

        //update Clicks And balance
        public int PutClickCounter(int id)
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

            String cStr = BuildInsertCommandUpdateClickCounter(id);      // helper method to build the insert string

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

        private String BuildInsertCommandUpdateClickCounter(int id) //The second C
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            //sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", business.Id, business.Name, business.Img, business.Rating, business.Category, business.Address, business.Phone, business.PriceRange);
            String prefix = "UPDATE Campaign_2021A_T4_1 SET clickCounter = clickCounter+1 , balance=balance-0.5 WHERE idR= " + id;
            command = prefix;

            return command;
        }

    }
}
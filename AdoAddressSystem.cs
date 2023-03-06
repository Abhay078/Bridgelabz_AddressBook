using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem
{
    public class AdoAddressSystem
    {
        AddressBook book=new AddressBook();
        string cs = ConfigurationManager.ConnectionStrings["AddressDb"].ConnectionString;
        SqlConnection con = null;
        public DataTable RetrieveData()
        {
            try
            {
                
                con = new SqlConnection(cs);
                con.Open();
                string query = "SELECT * FROM CONTACTLIST";
                SqlDataAdapter adapter = new SqlDataAdapter(query,con);
                DataTable dt=new DataTable();
                adapter.Fill(dt);
                foreach(DataRow row in dt.Rows) {
                    Console.WriteLine($" Name:-{row[0]} {row[1]}\tCity :- {row[2]}\tAddress:- {row[3]}\tState :- {row[4]}\tZIP :- {row[5]}\tPhone  :- {row[6]}\tEmail :- {row[7]}");
                }
                return dt;

            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.Message);
                return null;

            }
            finally { con.Close(); }

        }
        public bool UpdateAddressBook(string firstname)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                Console.WriteLine("Welcome to Updating Information .....");
                Console.WriteLine("Enter the updated firstname ");
                string first = Console.ReadLine();
                Console.WriteLine("Enter the updated lastname ");
                string last = Console.ReadLine();
                Console.WriteLine("Enter the updated city ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter the updated state ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter the updated address ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter the updated zip ");
                string zip = Console.ReadLine();
                Console.WriteLine("Enter the updated Phone ");
                string Phone = Console.ReadLine();
                Console.WriteLine("Enter the updated Email ");
                string Email = Console.ReadLine();
                string query = "UPDATE CONTACTLIST SET firstName=@first, lastName=@last, city=@city, address=@address, state=@state, zip=@zip,Phone=@Phone,email=@Email WHERE firstName=@first";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@first", first);
                cmd.Parameters.AddWithValue("@last", last);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@zip", zip);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.CommandText = query;
                cmd.Connection= con;
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Console.WriteLine("Information is updated");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to Update data");
                    return false;
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }


        }

        public bool DeleteContact(string name)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                string query = "DELETE FROM CONTACTLIST WHERE firstName=@name";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.CommandText= query;
                cmd.Connection= con;
                int a= cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Console.WriteLine("Contact deleted Successfully");
                    return true;

                }
                else
                {
                    Console.WriteLine("Some problemoccur while deleting");
                    return false;
                }




            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable RetrieveContactBasedOnDate()
        {
            try
            {

                con = new SqlConnection(cs);
                con.Open();
                string query = "SELECT * FROM CONTACTLIST WHERE date_Introduced=CAST(GETDATE() AS DATE)";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($" Name:-{row[0]} {row[1]}\tCity :- {row[2]}\tAddress:- {row[3]}\tState :- {row[4]}\tZIP :- {row[5]}\tPhone  :- {row[6]}\tEmail :- {row[7]}\tDATE :- {row[8]} ");
                }
                return dt;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
            finally { con.Close(); }

        }






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AddressBookSystem
{
    public class AdoAddressSystem
    {
        string cs = ConfigurationManager.ConnectionStrings["AddressDb"].ConnectionString;
        public DataTable RetrieveData()
        {
            try
            {
                
                SqlConnection con = new SqlConnection(cs);
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

        }

       


    }
}

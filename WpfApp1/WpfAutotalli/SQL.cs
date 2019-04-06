using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfAutotalli
{
    public class SQL
    {
        public static List<Auto> GetAutosDB()
        {
            //Haetaan kaikki rivit taulusta
            List<Auto> autosdb = new List<Auto>();
            string server = WpfAutotalli.Properties.Settings.Default.Server;
            string db = WpfAutotalli.Properties.Settings.Default.DB;
            string pw = WpfAutotalli.Properties.Settings.Default.Pwd;
            string user = WpfAutotalli.Properties.Settings.Default.User;

            
            try
            {
                DataTable dt = new DataTable();

                MySqlConnection con = new MySqlConnection(
                    new MySqlConnectionStringBuilder()
                    {
                        Server = server,
                        Database = db,
                        UserID = user,
                        //Password = pw
                    }.ConnectionString
                );

                using (con)
                {
                    con.Open();
                    string t = "SELECT * From autotalli";

                    MySqlCommand cmd = new MySqlCommand(t, con);

                    using (MySqlDataAdapter a = new MySqlDataAdapter(t, con))
                    {
                        DataTable temp = new DataTable();
                        a.Fill(temp);
                        dt = temp;
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    autosdb.Add(
                        new Auto()
                        {
                            Brand = Convert.ToString(row["merkki"]),
                            Model = Convert.ToString(row["malli"]),
                            YearModel = Convert.ToInt32(row["vm"]),
                            KM = Convert.ToInt32(row["km"]),
                            Price = Convert.ToInt32(row["hinta"])

                        });
                }

                    return autosdb;
            }
            catch
            {

                throw;
            }
        }
    }
}

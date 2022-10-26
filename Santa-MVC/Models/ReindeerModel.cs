using System.Data;
using MySql.Data.MySqlClient;



namespace Santa_MVC.Models
{
    public class ReindeerModel
    {
        IConfiguration _configuration;
        private string connectionString;

        public ReindeerModel(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllReindeers()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Reindeer;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable reindeerTable = ds.Tables["result"];
            dbcon.Close();

            return reindeerTable;

        }

        public void InsertReindeer(int rNr, string rClanName, string rSubspecies, string rName, string rStink, string rRegion, int rGroupBellonging)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();

            string insertQuery = "INSERT INTO Reindeer(Nr, ClanName, Subspecies, ReindeerName, Stink, Region, GroupBellonging)" +
                "VALUES(@rNr, @rClanName, @rSubspecies, @rName, @rStink, @rRegion, @rGroupBellonging)";

            MySqlCommand sqlCmd = new MySqlCommand(insertQuery, dbcon);
            sqlCmd.Parameters.AddWithValue("@rNr", rNr);
            sqlCmd.Parameters.AddWithValue("@rClanName", rClanName);
            sqlCmd.Parameters.AddWithValue("@rSubspecies", rSubspecies);
            sqlCmd.Parameters.AddWithValue("@rName", rName);
            sqlCmd.Parameters.AddWithValue("@rStink", rStink);
            sqlCmd.Parameters.AddWithValue("@rRegion", rRegion);
            sqlCmd.Parameters.AddWithValue("@rGroupBellonging", rGroupBellonging);

            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();


        }


        public void RemoveReindeer(int rNr)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();

            MySqlCommand rmQuery = new("DELETE FROM Reindeer WHERE Nr =@rNR", dbcon);
            
            rmQuery.Parameters.AddWithValue("@rNr", rNr);
            int rows = rmQuery.ExecuteNonQuery();

            dbcon.Close();

        }

        public void SearchReindeer(int rNr)
        {
            MySqlConnection dbcon = new MySqlConnection (connectionString);
            dbcon.Open();

            MySqlCommand sqlQuery = new("SELECT * FROM Reindeer WHERE ");
        }

    }
}





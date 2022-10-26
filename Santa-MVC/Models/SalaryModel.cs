using System.Data;
using MySql.Data.MySqlClient;

namespace Santa_MVC.Models

{
    public class SalaryModel
    {
        IConfiguration _configuration;
        private string connectionString;

        public SalaryModel(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetSalary()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("CALL ListOfSalary();", dbcon);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "result");
            DataTable salaryTable = dataSet.Tables["result"];

            dbcon.Close();

            return salaryTable;

        }


    }
}

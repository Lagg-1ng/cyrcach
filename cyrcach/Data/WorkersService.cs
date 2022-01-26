using System.Data;
using System.Data.SqlClient;
using cyrcach.Pages;
using MySql.Data.MySqlClient;

namespace cyrcach.Data
{
    public class WorkersService
    {
        private IConfiguration config;
        public WorkersService(IConfiguration configuration)
        {
            config = configuration;
        }
        private string ConnectionString
        {
            get
            {
                string _server = config.GetValue<string>("DbConfig:ServerName");
                string _database = config.GetValue<string>("DbConfig:DatabaseName");
                string _username = config.GetValue<string>("DbConfig:UserName");
                return ($"server={_server};username={_username};database={_database}");
            }
        }
        public async Task<List<Worker>> GetWorkers()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT * FROM `animals`", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_animals"]);
                s.Animals = row["animals"] as string;
                s.Age = Convert.ToInt32(row["age"]);
                s.Gender = row["gender"] as string;
               // s.Time = Convert.ToDateTime(row["arrival_date_at_the_zoo"]);
                s.offspiring = row["offspring"] as string;
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        //public async Task<List<Worker>> GetWorkers1()
        //{
        //    List<Worker> workers = new List<Worker>();
        //    Worker s;
        //    DataTable dt = new DataTable();
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlDataAdapter da = new MySqlDataAdapter("Select * FROM cells", con);
        //    da.Fill(dt);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        s = new Worker();
        //        s.Id = Convert.ToInt32(row["id_cells"]);
        //        s.Id = Convert.ToInt32(row["id_animals"]);
        //        s.Id = Convert.ToInt32(row["id_medical_examination"]);
        //        s.Id = Convert.ToInt32(row["id_offspring"]);
        //        s.Id = Convert.ToInt32(row["id_feeding"]);
        //        workers.Add(s);
        //    }
        //    return await Task.FromResult(workers);
        //}
        public async Task<List<Worker>> GetWorkers2()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM cells", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_animals"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByID(int id)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM animals WHERE id_animals = {id}", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_animals"]);
                s.Animals = row["animals"] as string;
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByName(string Animals)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM animals WHERE animals = \"{Animals}\"", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_animals"]);
                s.Animals = row["animals"] as string;
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByCreate(int id_cells,int id_animals, int id_medical_examination, int id_offspring, int id_feeding)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`cells` (`id_cells`, `id_animals`, `id_medical_examination`, `id_offspring`, `id_feeding`) VALUES ('{id_cells}', '{id_animals}', '{id_medical_examination}', '{id_offspring}', '{id_feeding}');", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByCreate1(int id_animals, string type_animals, string animals, int age, string gender, DateTime arrival_date_at_the_zoo, string offspring)
        {
            string sqlFormattedDate = arrival_date_at_the_zoo.ToString("yyyy-MM-dd");
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO zoo.animals (id_animals, type_animals, animals, age, gender, arrival_date_at_the_zoo, offspring) VALUES ('{id_animals}', '{type_animals}', '{animals}', '{age}', '{gender}', '{sqlFormattedDate}', '{offspring}');", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByoffspring(int id_offspring,string? exchange, int id_exchange)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`offspring` (`id_offspring`, `exchange`, `id_exchange`) VALUES ('{id_offspring}', '{exchange}', '{id_exchange}');", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }

        public async Task<List<Worker>> GetWorkers3()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * FROM cells", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.ID_offspring = Convert.ToInt32(row["id_offspring"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }

        public async Task<List<Worker>> GetWorkers4()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * FROM offspring", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.ID_exchange = Convert.ToInt32(row["id_exchange"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorkers5()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * FROM cells", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.ID_feeding = Convert.ToInt32(row["id_feeding"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorkers6()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * FROM cells", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.ID_med = Convert.ToInt32(row["id_medical_examination"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorkers8()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * FROM cells", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.ID_exchange = Convert.ToInt32(row["id_medical_examination"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByMed(int? id_med, string? animals, int? weight, int? height, string? vaccination, string? disease, string? physical_condition, DateTime date)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`medical_examination` (`id_medical_examination`, `animals`, `weight`, `height`, `vaccination`, `disease`, `physical_condition`, `date`) VALUES ('{id_med}', '{animals}', '{weight}','{height}', '{vaccination}', '{disease}','{physical_condition}','{date}');", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByFeeding(int id_offspring, int? sezon, DateTime date,int? count_in_day,int? id_menu)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`feeding` (`id_feeding`, `sezon`, `date`, `coun_in_day`, `id_menu`) VALUES ('{id_offspring}', '{sezon}', '{date}', '{count_in_day}', '{id_menu}');", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByExchange(int id_exchange, string? where, string? where_from, string? address, string? exchange_for)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`exchange` (`id_exchange`, `where`, `where_from`, `address`, `exchange_for`) VALUES  ('{id_exchange}', '{where}', '{where_from}', '{address}', '{exchange_for}');", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByDelet(int g)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"DELETE FROM zoo.animals WHERE animals.id_animals = {g}", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersUP(string type_animals, int id_animals, string animals, int age, string gender,DateTime arrival_date_at_the_zoo, string offspring)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"UPDATE `zoo`.`animals` SET `type_animals` = '{type_animals}',`animals` = '{animals}',`age` = '{age}',`gender` = '{gender}',`arrival_date_at_the_zoo` = '{arrival_date_at_the_zoo}',`offspring` = '{offspring}' WHERE `animals`.`id_animals` = {id_animals};", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
    }
}

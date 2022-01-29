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
                s.Time = Convert.ToDateTime(row["arrival_date_at_the_zoo"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorkers2()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM animals", con);
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
        public async Task<List<Worker>> CageShow()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT * FROM `cage`", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_cage"]);
                s.habitat = row["habitat"] as string;
                s.animals_count = Convert.ToInt32(row["animals_count"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> FeedingShow()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT * FROM `feeding`", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_feeding"]);
                s.date = Convert.ToDateTime(row["date"]);
                s.count_in_day = Convert.ToInt32(row["coun_in_day"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> MedShow()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT * FROM `medical_examination`", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_medical_examination"]);
                s.date = Convert.ToDateTime(row["date"]);
                s.weight = Convert.ToInt32(row["weight"]);
                s.Animals = row["animals"] as string;
                s.vaccination = row["vaccination"] as string;
                s.disease = row["disease"] as string;
                s.physical_condition = row["physical_condition"] as string;
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> CreateAnimals(int id_animals, string type_animals, string animals, int age, string gender, DateTime arrival_date_at_the_zoo, int id_feeding,int Medical_id,int cage_id)
        {
            string sqlFormattedDate = arrival_date_at_the_zoo.ToString("yyyy-MM-dd");
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`animals` (`id_animals`, `type_animals`, `animals`, `age`, `gender`, `arrival_date_at_the_zoo`, `id_feeding`, `Medical_id`, `cage_id`) VALUES ('{id_animals}', '{type_animals}', '{animals}', '{age}', '{gender}', '{sqlFormattedDate}', '{id_feeding}','{Medical_id}','{cage_id}');", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["animals"] as string;
                s.date = Convert.ToDateTime(row["arrival_date_at_the_zoo"]);
                s.TAnimals = row["type_animals"] as string;
                s.ID_animals = Convert.ToInt32(row["id_animals"]);
                s.Age = Convert.ToInt32(row["age"]);
                s.Id_fed = Convert.ToInt32(row["id_feeding"]);
                s.Gender = row["gender"] as string;
                s.Id_med = Convert.ToInt32(row["Medical_id"]);
                s.Id_cage = Convert.ToInt32(row["cage_id"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> CreateCage(int id_cage, string habitat, int animals_count)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`cage` (`id_cage`, `habitat`, `animals_count`) VALUES ('{id_cage}', '{habitat}', '{animals_count}');", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["habitat"] as string;
                s.Id_cage = Convert.ToInt32(row["id_cage"]);
                s.animals_count = Convert.ToInt32(row["animals_count"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> CreateFeeding(int id_feeding,DateTime date, int count_in_day)
        {
            string sqlFormattedDate = date.ToString("yyyy-MM-dd");
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`feeding` (`id_feeding`, `date`, `coun_in_day`) VALUES ('{id_feeding}', '{sqlFormattedDate}', '{count_in_day}');", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.date = Convert.ToDateTime(row["date"]);
                s.Id_fed = Convert.ToInt32(row["id_feeding"]);
                s.count_in_day = Convert.ToInt32(row["coun_in_day"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> CreateMed(int id_medical_examination, string animals, DateTime date,int weight,string vaccination, string disease, string physical_condition)
        {
            string sqlDate = date.ToString("yyyy-MM-dd");
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"INSERT INTO `zoo`.`medical_examination` (`id_medical_examination`, `animals`, `weight`, `vaccination`, `disease`, `physical_condition`, `date`) VALUES ('{id_medical_examination}', '{animals}', '{weight}', '{vaccination}', '{disease}','{physical_condition}','{sqlDate}');", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["animals"] as string;
                s.disease = row["disease"] as string;
                s.weight = Convert.ToInt32(row["weight"]);
                s.physical_condition = row["physical_condition"] as string;
                s.Id_med = Convert.ToInt32(row["id_medical_examination"]);
                s.animals_count = Convert.ToInt32(row["animals_count"]);
                s.date = Convert.ToDateTime(row["date"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorckersByDelet(int g)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"DELETE FROM `zoo`.`animals` WHERE `animals`.`id_animals` = {g}", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> DeletMed(int g)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"DELETE FROM `zoo`.`medical_examination` WHERE `medical_examination`.`id_medical_examination` = {g}", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> DeletFeed(int g)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"DELETE FROM `zoo`.`feeding` WHERE `feeding`.`id_feeding` = {g}", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> DeletCage(int g)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"DELETE FROM `zoo`.`cage` WHERE `cage`.`id_cage` = {g}", con);
            da.Fill(dt);
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> VivodFed(string animals, DateTime date,int? count_in_day)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT a.animals, f.date, f.coun_in_day FROM animals a JOIN feeding f ON a.id_feeding = f.id_feeding WHERE `animals`='{animals}';",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["animals"] as string;
                s.date = Convert.ToDateTime(row["date"]);
                s.count_in_day = Convert.ToInt32(row["coun_in_day"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> VivodMed(string animals, int? weight, string vaccination, string physical_condition, string disease)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT a.animals,m.weight, m.vaccination, m.physical_condition,m.disease FROM animals a JOIN medical_examination m ON a.Medical_id = m.id_medical_examination WHERE a.`animals`='{animals}';", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["animals"] as string;
                s.weight = Convert.ToInt32(row["weight"]);
                s.vaccination = row["vaccination"] as string;
                s.physical_condition = row["physical_condition"] as string;
                s.disease = row["disease"] as string;
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> VivodCage(string animals, int? animals_count, string habitat)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlDataAdapter da = new MySqlDataAdapter($"SELECT a.animals,c.habitat, c.animals_count FROM animals a JOIN cage c ON a.cage_id = c.id_cage WHERE a.`animals`='{animals}';", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["animals"] as string;
                s.animals_count = Convert.ToInt32(row["animals_count"]);
                s.habitat = row["habitat"] as string;
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }


        public async Task<List<Worker>> GetWorckersUP(string type_animals, int id_animals, int id_feeding, int cage_id, string gender, DateTime arrival_date_at_the_zoo, string animals, int age, int Medical_id)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            string sqlFormattedDate = arrival_date_at_the_zoo.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"UPDATE `zoo`.`animals` SET `id_animals` = '{id_animals}',`type_animals` = '{type_animals}',`animals` = '{animals}',`age` = '{age}',`gender` = '{gender}',`arrival_date_at_the_zoo` = '{sqlFormattedDate}',`id_feeding` = '{id_feeding}',`Medical_id` = '{Medical_id}',`cage_id` = '{cage_id}' WHERE `animals`.`id_animals` = '{id_animals}'; ", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Animals = row["animals"] as string;
                s.date = Convert.ToDateTime(row["arrival_date_at_the_zoo"]);
                s.TAnimals = row["type_animals"] as string;
                s.ID_animals = Convert.ToInt32(row["id_animals"]);
                s.Age = Convert.ToInt32(row["age"]);
                s.Id_fed = Convert.ToInt32(row["id_feeding"]);
                s.Gender = row["gender"] as string;
                s.Id_med = Convert.ToInt32(row["Medical_id"]);
                s.Id_cage = Convert.ToInt32(row["cage_id"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> UPCage(int id_cage, int animals_count, string habitat)
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"UPDATE `zoo`.`cage` SET `id_cage` = '{id_cage}',`habitat` = '{habitat}',`animals_count` = '{animals_count}' WHERE `cage`.`id_cage` ='{id_cage}';", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.habitat = row["habitat"] as string;
                s.Id_cage = Convert.ToInt32(row["id_cage"]);
                s.animals_count = Convert.ToInt32(row["animals_count"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> UPMed(int id_medical_examination, int weight, string animals, string vaccination, string disease,string physical_condition,DateTime date)
        {
            string sqlDate = date.ToString("yyyy-MM-dd");
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"UPDATE `zoo`.`medical_examination` SET `id_medical_examination` = '{id_medical_examination}',`animals` = '{animals}',`weight` = '{weight}',`vaccination` = '{vaccination}',`disease` = '{disease}',`physical_condition` = '{physical_condition}',`date` = '{sqlDate}' WHERE `medical_examination`.`id_medical_examination` ='{id_medical_examination}';", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id_med = Convert.ToInt32(row["id_medical_examination"]);
                s.Animals = row["animals"] as string;
                s.weight = Convert.ToInt32(row["weight"]);
                s.vaccination = row["vaccination"] as string;
                s.disease = row["disease"] as string;
                s.physical_condition = row["physical_condition"] as string;
                s.date = Convert.ToDateTime(row["date"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
        public async Task<List<Worker>> GetWorkers3()
        {
            List<Worker> workers = new List<Worker>();
            Worker s;
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM feeding", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id_fed = Convert.ToInt32(row["id_feeding"]);
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
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM medical_examination", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id_med = Convert.ToInt32(row["id_medical_examination"]);
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
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM cage", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id_cage = Convert.ToInt32(row["id_cage"]);
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
            MySqlDataAdapter da = new MySqlDataAdapter($"Select * FROM animals", con);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                s = new Worker();
                s.Id = Convert.ToInt32(row["id_animals"]);
                workers.Add(s);
            }
            return await Task.FromResult(workers);
        }
    }
}

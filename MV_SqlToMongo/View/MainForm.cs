using AutoMapper;
using Microsoft.Data.SqlClient;
using MongoDB.Driver;
using MV_SqlToMongo.DBContext;
using MV_SqlToMongo.Model;
using System.Configuration;

namespace MV_SqlToMongo.View
{
    public partial class MainForm : Form
    {
        private IMapper _IMapper;
        public MainForm()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            _IMapper = config.CreateMapper();
            InitializeComponent();
        }

        private void btnChuyenDuLieu_Click(object sender, EventArgs e)
        {
            //dmdvcs dmdvcs = new dmdvcs();
            string? mongoHost = ConfigurationManager.AppSettings["MongoHost"];
            string? mongoCollectionName = ConfigurationManager.AppSettings["MongoCollectionName"];
            string? mongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SQLDatabase"].ConnectionString;

            var dbContext = new BranchContext(mongoHost);
            var mongoCollection = dbContext.GetCollection<Branch>(mongoCollectionName, mongoDatabaseName);

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                // Truy vấn dữ liệu từ SQL Server
                string sqlQuery = "SELECT * FROM dmdvcs";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Chuyển dữ liệu từ SQL Server sang MongoDB
                while (reader.Read())
                {
                    dmdvcs dmdvcs = new dmdvcs
                    {
                        dmdvcs_id = (reader["dmdvcs_id"] != DBNull.Value) ? Guid.Parse(reader["dmdvcs_id"].ToString()) : Guid.Empty,
                        ma_dvcs = (reader["ma_dvcs"] != DBNull.Value) ? reader["ma_dvcs"].ToString() : string.Empty,
                        ten_dvcs = (reader["ten_dvcs"] != DBNull.Value) ? reader["ten_dvcs"].ToString() : string.Empty,
                        ms_thue = (reader["ms_thue"] != DBNull.Value) ? reader["ms_thue"].ToString() : string.Empty,
                        post_invoice = (reader["post_invoice"] != DBNull.Value) ? reader["post_invoice"].ToString() : string.Empty,
                        dia_chi = (reader["dia_chi"] != DBNull.Value) ? reader["dia_chi"].ToString() : string.Empty,
                        email = (reader["email"] != DBNull.Value) ? reader["email"].ToString() : string.Empty,
                        user_new = (reader["user_new"] != DBNull.Value) ? reader["user_new"].ToString() : string.Empty,
                        date_new = (reader["date_new"] != DBNull.Value) ? Convert.ToDateTime(reader["date_new"]) : DateTime.MinValue,
                        user_edit = (reader["user_edit"] != DBNull.Value) ? reader["user_edit"].ToString() : string.Empty,
                        date_edit = (reader["date_edit"] != DBNull.Value) ? Convert.ToDateTime(reader["date_edit"]) : DateTime.MinValue,
                        is_use = (reader["is_use"] != DBNull.Value) ? Convert.ToBoolean(reader["is_use"]) : false,
                        sdt = (reader["sdt"] != DBNull.Value) ? reader["sdt"].ToString() : string.Empty,
                        token = (reader["token"] != DBNull.Value) ? reader["token"].ToString() : string.Empty
                    };

                    var filter = Builders<Branch>.Filter.Eq(x => x.branchId, dmdvcs.dmdvcs_id);
                    var existingBranch = mongoCollection.Find(filter).FirstOrDefault();

                    if (existingBranch == null)
                    {
                        Branch branch = _IMapper.Map<Branch>(dmdvcs);
                        mongoCollection.InsertOne(branch);
                    }
                }
                Console.WriteLine("Data migration completed.");
            }
        }
    }
}

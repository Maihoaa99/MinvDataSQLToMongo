using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MV_SqlToMongo.Model
{
    public class Branch
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid branchId { get; set; }
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string taxCode { get; set; }
        public string addressApi { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string userNew { get; set; }
        public DateTime dateNew { get; set; }
        public string userEdit { get; set; }
        public DateTime dateEdit { get; set; }
        public bool isUse { get; set; }
        public int DF_dmdvcs_is_use { get; set; } = 1;
        public string phone { get; set; }
        public string token { get; set; }
        public string contact { get; set; }
        public Branch()
        {
            branchId = Guid.NewGuid();
        }
    }
}

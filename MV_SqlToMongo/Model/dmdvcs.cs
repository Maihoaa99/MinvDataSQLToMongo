using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MV_SqlToMongo.Model
{
    [Table("dmdvcs")]
    public class dmdvcs
    {
        [Key]
        public Guid dmdvcs_id { get; set; }
        public string ma_dvcs { get; set; }
        public string ten_dvcs { get; set; }
        public string ms_thue { get; set; }
        public string post_invoice { get; set; }
        public string dia_chi { get; set; }
        public string email { get; set; }
        public string user_new { get; set; }
        public DateTime date_new { get; set; }
        public string user_edit { get; set; }
        public DateTime date_edit { get; set; }
        public bool is_use { get; set; }
        public string sdt { get; set;}
        public string token { get; set; }
    }
}

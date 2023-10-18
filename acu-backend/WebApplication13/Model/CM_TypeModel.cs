using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class CM_TypeModel
    {
        [Key]
        public int CM_type_id { get; set; }//使用者中藥類型編號
        public string CM_type_name { get; set; }
        public bool isdel { get; set; }
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }
    }
}

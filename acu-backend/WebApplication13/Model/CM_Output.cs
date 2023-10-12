using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class CM_output
    {
        [Key]
        public Guid CM_output_id { get; set; } //使用者中藥類型編號
        public Guid user_id { get; set; }
        public DateTime CM_output_date { get; set; }//紀錄日期
        public string CM_output_options { get; set; }// 勾選內容
        public int CM_type_id { get; set; }//類型
        public bool isdel { get; set; }
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }

    }
}

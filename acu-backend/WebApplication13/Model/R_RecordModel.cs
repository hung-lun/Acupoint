using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class R_RecordModel
    {
        [Key]
        public Guid R_record_id { get; set; } // 復健紀錄編號
        public Guid user_id { get; set; }
        public DateTime R_record_date { get; set; }// 紀錄日期
        public Guid acupuncture_points_id { get; set; } //穴道編號
        public int R_record_finish { get; set; }//是否完成(0=未完成/1=已完成)
        public bool isdel { get; set; } 
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }
    }
}

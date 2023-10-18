using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class D_RecordModel

    {
        [Key]
        public Guid D_record_id { get; set; } //乾眼症診斷紀錄編號
        public Guid user_id { get; set; }
        public DateTime D_record_date { get; set; }//紀錄日期
    
        public Guid eye_question_id   { get; set; }
        ///問題編號 
        public int D_record_score { get; set; }//選擇的分數


        public bool isdel { get; set; }
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }

    }
}

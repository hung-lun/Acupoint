using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class Eye_QuestionModel
    {
        public int Id { get; set; }

        [Key]
        public Guid eye_question_id { get; set; } //乾眼症檢測問題編號
        public string eye_question_content { get; set; }//乾眼症檢測問題內容
        public bool isdel { get; set; }
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }
    }
}

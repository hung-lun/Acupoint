using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class CM_QuestionModel

    {
        public int Id { get; set; }

        [Key]
        public Guid CM_question_id{ get; set; }//使用者中藥類型編號
        public string CM_question{ get; set; }
        public int CM_type_id { get; set; }//類型(0=無症狀/1=肝腎陰虛型/2=肺陰不足型/3=脾胃溼熱型/4=脾肺伏熱型/5=肝氣鬱結型/6=脾肺虛寒型
        public bool isdel { get; set; }
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class GetCM_QuestionViewModel

    {
     public int Id { get; set; }
        public Guid CM_question_id{ get; set; }//使用者中藥類型編號
        public string CM_question{ get; set; }
    
    
    }
}

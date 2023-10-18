using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class GetD_RecordViewModel

    {
  
        public Guid eye_question_id   { get; set; }
        public string eye_question_content { get; set; }
        public string CM_output_options { get; set; }
        public int D_record_score { get; set; }//選擇的分數
     

    }
}

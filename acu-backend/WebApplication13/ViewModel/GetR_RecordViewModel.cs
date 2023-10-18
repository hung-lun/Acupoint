using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class GetR_RecordViewModel
    {
       
      
        public Guid acupuncture_points_id { get; set; } //穴道編號
        public string acupuncture_points_name { get; set; } //穴道編號

        public int R_record_finish { get; set; }//是否完成(0=未完成/1=已完成)
    
    }
}

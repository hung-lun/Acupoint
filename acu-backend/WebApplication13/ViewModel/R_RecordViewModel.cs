using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class R_RecordViewModel
    {
        public Guid user_id { get; set; }
        public Guid acupuncture_points_id { get; set; } //穴道編號
        public int R_record_finish { get; set; }//是否完成(0=未完成/1=已完成)
       
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class Acupuncture_PointsModel

    {
        [Key]
        public Guid acupuncture_points_id { get; set; } //穴位資訊編號
        public string acupuncture_points_name { get; set; }//穴道名稱
        public string acupuncture_points_location { get; set; }//穴道位置
        public string acupuncture_points_press { get; set; }//按壓方式
        public string acupuncture_points_detail { get; set; }//穴名介紹
        public string acupuncture_points_content { get; set; }//穴道介紹
        public bool isdel { get; set; }
        public string create_id { get; set; }
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }



    }
}

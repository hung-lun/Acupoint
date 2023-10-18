using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class Acupuncture_PointsViewModel

    {

        public string acupuncture_points_name { get; set; }//穴道名稱
        public string acupuncture_points_location { get; set; }//穴道位置
        public string acupuncture_points_press { get; set; }//按壓方式
        public string acupuncture_points_detail { get; set; }//穴名介紹
        public string acupuncture_points_content { get; set; }//穴道介紹
        public IFormFile acupuncture_points_img { get; set; }



    }
}

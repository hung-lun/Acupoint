using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class CM_OutputViewModel
    {
        public Guid CM_output_id { get; set; } //使用者中藥類型編號
     
        public DateTime CM_output_date { get; set; }//紀錄日期
        public string CM_output_options { get; set; }// 勾選內容
        public int CM_type_id { get; set; }//類型



    }
}

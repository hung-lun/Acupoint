using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class CM_TypeModel
    {
        [Key]
        public Guid CM_type_id { get; set; }//使用者中藥類型編號
        public Guid user_id { get; set; }
        public DateTime CM_type_date { get; set; }//紀錄日期
        public string CM_options { get; set; }// 勾選內容
        public int chinese_medicinal_type { get; set; }//類型
    }
}

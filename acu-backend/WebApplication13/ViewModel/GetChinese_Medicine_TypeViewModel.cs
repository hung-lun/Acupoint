using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{

    public class GetChinese_Medicine_TypeViewModel
    {

        public int CM_type_id { get; set; }
        public string CM_type_name { get; set; }//中藥種類
        public int TotalScore { get; set; }

    }
}

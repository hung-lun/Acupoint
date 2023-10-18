using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class GetChinese_Medicine_InformationViewModel

    {
     
   
        public string chinese_medicinal_materials { get; set; }//中藥製法用量
        public string chinese_medicinal_effect { get; set; }//中藥功效
        public string chinese_medicinal_main { get; set; }//中藥主治
        public string chinese_medicinal_explain { get; set; }//中藥方義
        public string chinese_medicinal_other { get; set; }//中藥加減
    
      

    }
}

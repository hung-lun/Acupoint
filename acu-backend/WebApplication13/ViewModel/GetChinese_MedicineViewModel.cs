using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class GetChinese_MedicineViewModel

    {
        public int Id { get; set; }
        public Guid chinese_medicine_id { get; set; } //中藥資訊編號
        public string chinese_medicine_name { get; set; }//中藥名稱
        public string chinese_medicine_taboo { get; set; }//中藥禁忌
        public string chinese_medicinal_materials { get; set; }//中藥製法用量
        public string chinese_medicinal_effect { get; set; }//中藥功效
        public string chinese_medicinal_main { get; set; }//中藥主治
        public string chinese_medicinal_explain { get; set; }//中藥方義
        public string chinese_medicinal_other { get; set; }//中藥加減
    
      

    }
}

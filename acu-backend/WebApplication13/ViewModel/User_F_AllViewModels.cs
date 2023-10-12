using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication13.ViewModel
{
    public class User_F_AllViewModels
    {
        public Guid user_id { get; set; }
        public string user_account { get; set; }
        public string user_name { get; set; }
        public int? user_gender { get; set; }
        public int? user_age { get; set; }
    }
}

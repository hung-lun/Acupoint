using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication13.ViewModel
{
    public class User_B_AllViewModels
    {
        public Guid user_id { get; set; }
        public string user_account { get; set; }
        public string user_name { get; set; }
        public bool user_level { get; set; }
        public int user_start { get; set; }

    }
}

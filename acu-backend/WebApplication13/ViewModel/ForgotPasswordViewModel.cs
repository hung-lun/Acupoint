using System.ComponentModel.DataAnnotations;

namespace WebApplication13.ViewModel
{
    public class ForgotPasswordViewModel
    {
        public string user_account { get; set; }
        public string user_authcode { get; set; }
        public string New_Pwd { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication13.ViewModel
{
    public class EmailAuthcode
    {
        public string user_email { get; set; }
        // 信箱驗證碼
        public string user_authcode { get; set; }
    }
}

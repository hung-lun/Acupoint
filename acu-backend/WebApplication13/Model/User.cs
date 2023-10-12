using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Model
{
    public class User

    {
        [Key]
        public Guid user_id { get; set; } = Guid.NewGuid();
        public string user_account { get; set; }


        // 密碼
        //[DisplayName("密碼:")]
        // [Required(ErrorMessage = "請輸入密碼")]
        //  [StringLength(20, MinimumLength = 8, ErrorMessage = "帳號長度需介於8-20字元")]
        public string user_password { get; set; }
        // 姓名
        //public string user_newpassword { get; set; }
        public string user_name { get; set; }
        //性別
        public int  user_gender { get; set; }
        //年齡
        public int  user_age { get; set; }

        // 信箱驗證碼
        public string user_authcode { get; set; }
        public int user_start { get; set; }
      
        // 管理者
        public bool user_level { get; set; }
        public bool isdel { get; set; } = false;
        public DateTime create_time { get; set; }
        public string? update_id { get; set; }
        public DateTime? update_time { get; set; }





    }
}

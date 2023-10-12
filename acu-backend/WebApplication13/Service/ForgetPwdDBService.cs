
using WebApplication13.Service;
using System.Data.SqlClient;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication13.Model;

namespace DI.Service
{
    public class ForgetPwdDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        //發送email的人
        private string gmail_account = "tnny2455@gmail.com"; //Gmail 帳號
        private string gmail_password = "soak ypjf dvwn enle"; //Gmail 密碼
        private string gmail_mail = "tnny2455@gmail.com"; //Gmail 信箱

        public ForgetPwdDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }


        #region 查詢一筆資料(判斷資料庫是否有此email)
        public int forget_pwd(string user_account)
        {
            //查詢一筆資料(判斷資料庫是否有此email)
            SqlConnection conn = new SqlConnection(connectionString);
            //Sql 語法
            string sql = $@"SELECT COUNT(*) FROM ""user"" where user_account ='{user_account}' and user_start='1' ";
            conn.Open();

            // 執行 Sql 指令
            SqlCommand command = new SqlCommand(sql, conn);
            int num = (int)command.ExecuteScalar();

            if (num > 0)
            {
                //驗證碼
                string[] Code ={ "A", "B", "C", "D", "E", "F", "G", "H",
                 "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U",
                 "V", "W", "X", "Y", "Z", "2", "3", "4", "5", "6",
                 "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h",
                 "i", "j", "k", "m", "n", "p", "q", "r", "s", "t",
                 "u", "v", "w", "x", "y", "z" };
                // 宣告初始為空的驗證碼字串
                string ValidateCode = string.Empty;
                // 宣告可產生隨機數值的物件
                Random rd = new Random();
                // 使用迴圈產生出驗證碼
                for (int i = 0; i < 10; i++)
                {
                    ValidateCode += Code[rd.Next(Code.Count())];
                }

                //信件檔案
                string filePath = @"View/ForgetPwdEmail.html";
                string TempMail = System.IO.File.ReadAllText(filePath);




                //取使用者姓名
                string name_sql = $@"SELECT user_name FROM ""user"" where user_account ='{user_account}'";
                SqlCommand name_command = new SqlCommand(name_sql, conn);
                string User_name = name_command.ExecuteScalar().ToString();

                // 將使用者資料填入
                string TempString;
                TempMail = TempMail.Replace("{{UserName}}", User_name);
                TempMail = TempMail.Replace("{{ValidateCode}}", ValidateCode);


                //寄email

                // 建立寄信用 Smtp 物件，這裡使用 Gmail 為例
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                // 設定使用的 Port，這裡設定 Gmail 所使用的
                SmtpServer.Port = 587;
                // 建立使用者憑據，這裡要設定您的 Gmail 帳戶
                SmtpServer.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);

                // 開啟 SSL
                SmtpServer.EnableSsl = true;

                // 宣告信件內容物件
                MailMessage mail = new MailMessage();
                // 設定來源信箱
                mail.From = new MailAddress(gmail_mail);
                // 設定收信者信箱
                mail.To.Add(user_account);
                // 設定信件主旨
                mail.Subject = " 忘記密碼驗證碼信 ";
                // 設定信件內容
                mail.Body = TempMail;
                // 設定信件內容為 HTML 格式
                mail.IsBodyHtml = true;
                // 送出信件
                SmtpServer.Send(mail);


                //修改資料庫驗證碼欄位
                string upd_pwd_sql = $@"UPDATE ""user"" SET user_authcode='{ValidateCode}' WHERE user_account ='{user_account}'";
                SqlCommand upd_pwd_command = new SqlCommand(upd_pwd_sql, conn);
                upd_pwd_command.ExecuteNonQuery();

                conn.Close();

                return 1;
            }
            else
            {
                //資料庫未有此信箱
                return 0;
            }

        }
        #endregion



        #region 驗證驗證碼
        public string forget_pwd_code(string user_account, string code)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = $@"SELECT * FROM ""user"" where user_account ='{user_account}' and user_start='1' ";
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            string useraccount = null;
            string usercode = null;
            while (reader.Read())
            {
                useraccount = reader["user_account"].ToString();
                usercode = reader["user_authcode"].ToString();
            }
            conn.Close();
            if (usercode == code)
            {
                //驗證碼錯誤
                return "驗證碼成功";
            }
            else
            {
                //驗證成功
                return "驗證碼錯誤";
            }
        }
        #endregion


        #region 修改密碼
        public string upd_pwd(string user_account, string pwd)
        {
            string USER_pwd = _userService.HashPassword(pwd);
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //修改資料庫驗證碼欄位
            string upd_pwd_sql = $@"UPDATE ""user"" SET user_password='{USER_pwd}' WHERE user_account ='{user_account}'";
            SqlCommand upd_pwd_command = new SqlCommand(upd_pwd_sql, conn);
            int num = upd_pwd_command.ExecuteNonQuery();
            conn.Close();
            if (num > 0)
            {
                return "密碼修改成功！";
            }
            else
            {
                return "修改失敗，請重試！";
            }
        }
        #endregion
    }
}



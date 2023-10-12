using System.Net.Mail;
using System.Security.Principal;

namespace WebApplication13.Service
{
    public class MailDBService
    {


        private string gmail_account = "tnny2455@gmail.com"; //Gmail 帳號
        private string gmail_password = "soak ypjf dvwn enle"; //Gmail 密碼
        private string gmail_mail = "tnny2455@gmail.com"; //Gmail 信箱
        //寄會員驗證信
        // 產生驗證碼方法
        public string GetValidateCode()
        {
            // 設定驗證碼字元的陣列
            string[] Code ={ "A", "B", "C", "D", "E", "F", "G", "H", "I",
                 "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U",
                 "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6",
                 "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h",
                 "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t",
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
            // 回傳驗證碼
            return ValidateCode;
        }
    
    public string GetRegisterMailBody(string TempString, string UserName, string ValidateCode)

    {
        // 將使用者資料填入
        TempString = TempString.Replace("{{UserName}}", UserName);
       // TempString = TempString.Replace("{{ValidateUrl}}", ValidateUrl);
        TempString = TempString.Replace("{{ValidateCode}}", ValidateCode);
            // 回傳最後結果
            return TempString;
    }

    // 寄驗證信的方法
    public void SendRegisterMail(string MailBody, string ToEmail)
    {

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
        mail.To.Add(ToEmail);
        // 設定信件主旨
        mail.Subject = " 會員註冊確認信 ";
        // 設定信件內容
        mail.Body = MailBody;
        // 設定信件內容為 HTML 格式
        mail.IsBodyHtml = true;
        // 送出信件
        SmtpServer.Send(mail);
    }

    }
}


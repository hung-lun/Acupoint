namespace WebApplication13.Security
{
    //JWT 內容設計
    public class JwtObject
{
       
        public string user_account { get; set; }
    public string Role { get; set; }
    // 到期時間
    public string Expire { get; set; }
}   

}

using System.Data.SqlClient;
using System.Text;
using WebApplication13.Model;
using System.Security.Cryptography;
using WebApplication13.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;
using FluentAssertions.Equivalency;

namespace WebApplication13.Service
{
    public class UserDBService
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public UserDBService(IConfiguration Configuration)
        {
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }
        #region 後－使用者總覽
        public List<User_B_AllViewModels> B_AllUser(string search)
        {
            string Sql = string.Empty;
            //如果搜尋都是空值
            if (string.IsNullOrWhiteSpace(search) == true)
            {
                Sql = @"SELECT * FROM ""user"" where isdel='false'";
            }
            else if (string.IsNullOrWhiteSpace(search) == false)
            {
                Sql = $@"SELECT * FROM ""user"" where (user_account LIKE '%{search}%' or user_name LIKE '%{search}%') and isdel='0'";
            }

            List<User_B_AllViewModels> DataList = new List<User_B_AllViewModels>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User_B_AllViewModels Data = new User_B_AllViewModels();
                        Data.user_id = (Guid)reader["user_id"];
                        Data.user_account = reader["user_account"].ToString();
                        Data.user_name = reader["user_name"].ToString();
                        Data.user_level = (bool)reader["user_level"];
                        Data.user_start = (int)reader["user_start"];
                        DataList.Add(Data);
                    }
                }
                catch (Exception e)
                {
                    //丟出錯誤
                    throw new Exception(e.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
                //return DataList;
                return DataList.OrderBy(item => item.user_start).ThenBy(e => e.user_name).ToList();
            }
        }
        #endregion


        #region 後 - 修改狀態
        public string B_PutUser(User_B_UpdateViewModel value)
        {
            string sql = $@"UPDATE ""user"" SET user_start=@user_start WHERE user_id = @user_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@user_id", value.user_id);
                    command.Parameters.AddWithValue("@user_start", value.user_start);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "修改成功！";
                    }
                    else
                    {
                        return "修改失敗，請重試！";
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 前 - 個人資料總覽
        public List<User_F_AllViewModels> F_AllUser(Guid user_id)
        {
            string Sql = $@"SELECT * FROM ""user"" where ""user_id""='{user_id}' ";


            List<User_F_AllViewModels> DataList = new List<User_F_AllViewModels>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User_F_AllViewModels Data = new User_F_AllViewModels();
                        Data.user_id = (Guid)reader["user_id"];
                        Data.user_account = reader["user_account"].ToString();
                        Data.user_name = reader["user_name"].ToString();
                        Data.user_gender = (int)reader["user_gender"];
                        Data.user_age = (int)reader["user_age"];
                        DataList.Add(Data);
                    }
                }
                catch (Exception e)
                {
                    //丟出錯誤
                    throw new Exception(e.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
                return DataList;
            }
        }
        #endregion
        #region 前 - 修改資料
        public string F_PutUser(User_F_UpdateViewModel value)
        {
            string sql = $@"UPDATE ""user"" SET user_name=@user_name,user_gender=@user_gender,user_age=@user_age WHERE user_id = @user_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@user_id", value.user_id);
                    command.Parameters.AddWithValue("@user_name", value.user_name);
                    command.Parameters.AddWithValue("@user_gender", value.user_gender);
                    command.Parameters.AddWithValue("@user_age", value.user_age);
                    int row = command.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return "修改成功！";
                    }
                    else
                    {
                        return "修改失敗，請重試！";
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------

        #region
        public void Register(UserRegisterViewModel newMember, string AuthCode)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            newMember.user_password = HashPassword(newMember.user_password);
            string sql = string.Empty;


            sql = @"INSERT INTO ""user"" ( user_id, user_account,  user_password,user_name, user_gender, user_age,  user_authcode,user_start, user_level,
                    isdel,create_time,update_id,update_time) VALUES (@user_id, @user_account,@user_password,@user_name,@user_gender,@user_age,@user_authcode, @user_start,@user_level,@isdel,@create_time,@update_id ,@update_time)";

            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@user_id", Guid.NewGuid());
                command.Parameters.AddWithValue("@user_account", newMember.user_account);
                command.Parameters.AddWithValue("@user_password", newMember.user_password);
                command.Parameters.AddWithValue("@user_newpassword", newMember.user_newpassword);
                command.Parameters.AddWithValue("@user_name", newMember.user_name);
                command.Parameters.AddWithValue("@user_gender", newMember.user_gender);
                command.Parameters.AddWithValue("@user_age", newMember.user_age);
                command.Parameters.AddWithValue("@user_authcode", AuthCode);
                command.Parameters.AddWithValue("@user_start", 0);
                command.Parameters.AddWithValue("@user_level", 1);
                command.Parameters.AddWithValue("@isdel", 0);
                command.Parameters.AddWithValue("@create_time", DateTime.Now);
                command.Parameters.AddWithValue("@update_id", newMember.user_account);
                command.Parameters.AddWithValue("@update_time", DateTime.Now);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion
        //Hash密碼
        //用的方法
        public string HashPassword(string user_pwd)
        {

            //宣告Hash時所添加的無意義亂數值
            string satltkey = "1q2w3e4r5t6y7u8ui9o0po7tyy";
            string saltAndPassword = String.Concat(user_pwd, satltkey);
            SHA256CryptoServiceProvider sha256Hasher = new SHA256CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashDate = sha256Hasher.ComputeHash(PasswordData);
            string Hashresult = Convert.ToBase64String(HashDate);
            return Hashresult;

        }

        public string EmailCheck(string Account)
        {

            User Data = GetDataByAccount(Account);

            if (Data == null)
            {
                return "";
            }
            else
            {
                return "信箱已被註冊";
            }
        }

        #region 帳號註冊重複確認
        // 確認要註冊帳號是否有被註冊過的方法
        public string AccountCheck(string Account)
        {

            User Data = GetDataByAccount(Account);

            if (Data == null)
            {
                return "";
            }
            else
            {
                return "已被註冊";
            }
        }
        #endregion


        #region 查詢一筆資料
        // 藉由帳號取得單筆資料的方法

        public User GetDataByAccount(string Account)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            User Data = new User();

            //Sql 語法
            string sql = $@" select * from ""user"" where user_account =@user_account ";
            // 確保程式不會因執行錯誤而整個中斷
            try
            {
                // 開啟資料庫連線
                conn.Open();

                // 執行 Sql 指令
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@user_account", Account);
                command.ExecuteNonQuery();
                // 取得 Sql 資料
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                Data.user_id = (Guid)dr["user_id"];
                Data.user_account = dr["user_account"].ToString();
                Data.user_password = dr["user_password"].ToString();
                Data.user_name = dr["user_name"].ToString();
                Data.user_gender = Convert.ToInt32(dr["user_gender"]);
                Data.user_age = Convert.ToInt32(dr["user_age"]);
                Data.user_authcode = dr["user_authcode"].ToString();
                Data.user_level = Convert.ToBoolean(dr["user_level"]);
                Data.isdel = Convert.ToBoolean(dr["isdel"]);


                //DateTimeOffset thisDate2 = new DateTimeOffset(2011, 6, 10, 15, 24, 16,
                //                              TimeSpan.Zero);

            }
            catch (Exception e)
            {
                // 查無資料
                Data = null;
            }
            finally
            {
                // 關閉資料庫連線
                conn.Close();
            }
            // 回傳根據編號所取得的資料
            return Data;
        }
        #endregion
       
        #region 信箱驗證
        // 信箱驗證碼驗證方法
        public string EmailValidate(string user_account, string AuthCode)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            // 取得傳入帳號的會員資料
            User ValidateMember = GetDataByAccount(user_account);
            // 宣告驗證後訊息字串
            string ValidateStr = string.Empty;
            if (ValidateMember != null)
            {
                // 判斷傳入驗證碼與資料庫中是否相同
                if (ValidateMember.user_authcode == AuthCode)
                {

                    // 將資料庫中的驗證碼設為空
                    //sql 更新語法
                    string sql = $@"SELECT * FROM ""user"" where user_account ='{user_account}' and user_start='1' ";
                    // string sql = $@" update  ""user""  set  user_authcode = '{string.Empty}'  ,   user_start='1' where user_account = '{user_account}' ";

                    try
                    {
                        // 開啟資料庫連線
                        conn.Open();
                        // 執行 Sql 指令
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        // 丟出錯誤
                        throw new Exception(e.Message.ToString());
                    }
                    finally
                    {
                        // 關閉資料庫連線
                        conn.Close();
                    }
                    ValidateStr = " 帳號信箱驗證成功，現在可以登入了 ";
                }
                else
                {
                    ValidateStr = " 驗證碼錯誤，請重新確認或再註冊 ";
                }
            }
            else
            {
                ValidateStr = " 傳送資料錯誤，請重新確認或再註冊 ";
            }
            // 回傳驗證訊息
            return ValidateStr;
        }
        #endregion
        #region 登入確認
        // 登入帳密確認方法，並回傳驗證後訊息
        public string LoginCheck(string user_account, string user_pwd)
        {
            // 取得傳入帳號的會員資料
            User LoginUser = GetDataByAccount(user_account);


            // 判斷是否有此會員
            if (LoginUser != null)
            {
                // 判斷是否有經過信箱驗證，有經驗證驗證碼欄位會被清空
                //if (String.IsNullOrWhiteSpace(LoginUser.user_authcode))
                //{
                // 進行帳號密碼確認
                if (PasswordCheck(LoginUser, user_pwd))
                {
                    return "";
                }
                else
                {
                    return " 密碼輸入錯誤 ";
                }
            }
            //else
            //{
            //    return " 此帳號尚未經過 Email 驗證，請去收信 ";
            //}
            //}
            else
            {
                return " 無此會員帳號，請去註冊 ";
            }
        }
        #endregion




        #region 密碼確認
        // 進行密碼確認方法
        public bool PasswordCheck(User CheckMember, string user_pwd)
        {
            // 判斷資料庫裡的密碼資料與傳入密碼資料 Hash 後是否一樣
            bool result = CheckMember.user_password.Equals(HashPassword(user_pwd));
            // 回傳結果
            return result;
        }
        #endregion

        #region 變更密碼
        // 變更會員密碼方法，並回傳最後訊息
        public string ChangePassword(string user_account, string user_password, string NewPassword)

        {
            SqlConnection conn = new SqlConnection(connectionString);
            // 取得傳入帳號的會員資料
            User LoginUser = GetDataByAccount(user_account);
            // 確認舊密碼正確性
            if (PasswordCheck(LoginUser, user_password))
            {
                // 將新密碼 Hash 後寫入資料庫中
                LoginUser.user_password = HashPassword(NewPassword);
                //sql 修改語法
                string sql = $@" update  ""user""  set  user_password = '{LoginUser.user_password}' where user_account = '{user_account}' ";
                try
                {
                    // 開啟資料庫連線
                    conn.Open();
                    // 執行 Sql 指令
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    // 丟出錯誤
                    throw new Exception(e.Message.ToString());
                }
                finally
                {
                    // 關閉資料庫連線
                    conn.Close();
                }
                return " 密碼修改成功 ";
            }
            else
            {
                return " 舊密碼輸入錯誤 ";
            }
        }
        #endregion

        #region 取得角色
        // 取得會員的權限角色資料
        public string GetRole(string user_account)
        {
            // 宣告初始角色字串
            string Role = "User";
            // 取得傳入帳號的會員資料
            User LoginMember = GetDataByAccount(user_account);
            // 判斷資料庫欄位，用以確認是否為 Admon
            if (LoginMember.user_level == false)
            {
                Role += ",Admin"; // 添加 Admin
            }
            // 回傳最後結果
            return Role;
        }
        #endregion

        #region
        public void DeleteUser(int Id)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            string sql = $@" DELETE FROM ""user"" WHERE user_id = {Id}";
            try
            {
                // 開啟資料庫連線
                conn.Open();
                // 執行 Sql 指令
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // 丟出錯誤
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                // 關閉資料庫連線
                conn.Close();
            }

        }



        #endregion



    }
}

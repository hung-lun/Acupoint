
using WebApplication13.Service;
using System.Data.SqlClient;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication13.Model;
using WebApplication13.Controllers;
using System.Linq;
using WebApplication13.ViewModel;
using System.Security.Principal;

namespace WebApplication13.Service
{
    public class Eye_questionDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public Eye_questionDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }
        #region 新增診斷題目
        public string ShowDiagnostics(Eye_questionViewModel value)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            string sql = $@"INSERT INTO Eye_question
                        (eye_question_id,eye_question_content,isdel,create_id,create_time,update_id,update_time) 
                        VALUES (@eye_question_id,@eye_question_content,@isdel,@create_id,@create_time,@update_id,@update_time)";
           
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@eye_question_id", Guid.NewGuid());
                command.Parameters.AddWithValue("@eye_question_content", value.eye_question_content);
                command.Parameters.AddWithValue("@create_id", "Admin");
                command.Parameters.AddWithValue("@isdel", 0);
                command.Parameters.AddWithValue("@create_time", DateTime.Now);
                command.Parameters.AddWithValue("@update_id", "Admin");
                command.Parameters.AddWithValue("@update_time", DateTime.Now);
                int num = command.ExecuteNonQuery();
                if (num > 0)
                {
                    return "新增成功！";
                }
                else
                {
                    return "新增失敗，請重試！";
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
        #endregion
    }
}



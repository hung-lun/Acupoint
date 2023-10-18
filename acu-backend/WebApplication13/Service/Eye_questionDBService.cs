
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
        public string NewQuestion(Eye_questionViewModel value)
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

        #region 修改題目
        public string PutEye_Question(GetEye_questionViewModel value)
        {
            string sql = $@"UPDATE Eye_question SET eye_question_content=@eye_question_content WHERE eye_question_id=@eye_question_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@eye_question_id", value.eye_question_id);
                    command.Parameters.AddWithValue("@eye_question_content", value.eye_question_content);
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

        #region 刪除題目
        public string DeleteEye_Question(string eye_question_id)
        {
            string sql = $@"  UPDATE Eye_question SET isdel=@isdel WHERE eye_question_id = @eye_question_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@isdel", '1');
                    command.Parameters.AddWithValue("@eye_question_id", eye_question_id);
                    int num = command.ExecuteNonQuery();
                    if (num > 0)
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


        #region 總覽問題
        public List<GetEye_questionViewModel> GetQuestion()
        {
            string Sql = "SELECT * FROM Eye_question where isdel='false'  ORDER BY Id  ASC ";
            List< GetEye_questionViewModel> DataList = new List<GetEye_questionViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetEye_questionViewModel Data = new GetEye_questionViewModel();
                        Data.Id = Convert.ToInt32(reader["Id"]);
                        Data.eye_question_id = (Guid)reader["eye_question_id"];
                        Data.eye_question_content = reader["eye_question_content"].ToString();
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

        






    }
}



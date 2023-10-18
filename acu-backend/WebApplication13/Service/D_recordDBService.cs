
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
    public class D_recordDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public D_recordDBService(IConfiguration Configuration)
        {

            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }
        #region 送出診斷
        public string PostD_record(Guid user_id, Guid eye_question_id, int D_record_score)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string userCountQuery = $@"SELECT COUNT(*) AS COUNT FROM ""user"" WHERE ""user_id"" = @user_id AND user_start = '1'";
            string sql = "INSERT INTO D_record (D_record_id, user_id, D_record_date, eye_question_id, D_record_score, isdel, create_id, create_time, update_id, update_time)" +
                         "VALUES (@D_record_id, @user_id, @D_record_date, @eye_question_id, @D_record_score, @isdel, @create_id, @create_time, @update_id, @update_time)";
            SqlCommand userCountCmd = new SqlCommand(userCountQuery, conn);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                userCountCmd.Parameters.AddWithValue("@user_id", user_id);
                int userCount = (int)userCountCmd.ExecuteScalar();

                if (userCount <= 0)
                {
                    return "使用者不存在";
                }
                cmd.Parameters.AddWithValue("@D_record_id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@D_record_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@eye_question_id", eye_question_id);
                cmd.Parameters.AddWithValue("@D_record_score", D_record_score);
                cmd.Parameters.AddWithValue("@isdel", 0);
                cmd.Parameters.AddWithValue("@create_id", "Admin");
                cmd.Parameters.AddWithValue("@create_time", DateTime.Now);
                cmd.Parameters.AddWithValue("@update_id", "Admin");
                cmd.Parameters.AddWithValue("@update_time", DateTime.Now);

                int num = cmd.ExecuteNonQuery();

                if (num > 0)
                {
                    return "送出成功！";
                }
                else
                {
                    return "送出失敗，請重試！";
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

        #region 總覽診斷紀錄
        public List<GetD_RecordViewModel> GetD_record(Guid user_id, DateTime D_record_date)
        {

            string Sql = $@"SELECT * FROM ((D_record 
            inner join Eye_Question 
            on D_record.eye_question_id = Eye_Question.eye_question_id)
            inner join ""user"" 
            on D_record.""user_id""=""user"".""user_id"")
            where 
            ""user"".""user_id""= '{user_id}' and D_record.D_record_date = '{D_record_date}' ";

            List<GetD_RecordViewModel> DataList = new List<GetD_RecordViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetD_RecordViewModel Data = new GetD_RecordViewModel();
                        Data.eye_question_id = (Guid)(reader["eye_question_id"]);
                        Data.eye_question_content = reader["eye_question_content"].ToString();
                        Data.CM_output_options = reader["CM_output_options"].ToString();
                        Data.D_record_score = Convert.ToInt32(reader["D_record_score"]);
                        DataList.Add(Data);
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
                return DataList;
            }
        }
        #endregion



    }
}



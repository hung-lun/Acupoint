
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
    public class CM_questionDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public CM_questionDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }
     

        #region 新增症狀button
        public string NewGetCM_Question_Button(CM_QuestionViewModel value)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $@"INSERT INTO CM_question
                        (CM_question_id,CM_question,CM_type_id,isdel,create_id,create_time,update_id,update_time) 
                        VALUES (@CM_question_id,@CM_question,@CM_type_id,@isdel,@create_id,@create_time,@update_id,@update_time)";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@CM_question_id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@CM_question", value.CM_question);
                    command.Parameters.AddWithValue("@CM_type_id", value.CM_type_id);

                    command.Parameters.AddWithValue("@isdel", 0);
                    command.Parameters.AddWithValue("@create_id", "Admin");
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
        }
        #endregion
        //------------------------------------------------------------------前台-------------------------------------------------------------------------------------



        #region 總覽症狀button
        public List<GetCM_QuestionViewModel> GetCM_Question_Button()
        {
            string Sql = "SELECT * FROM CM_question where isdel='false' ORDER BY Id  ASC ";
            List<GetCM_QuestionViewModel> DataList = new List<GetCM_QuestionViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        GetCM_QuestionViewModel Data = new GetCM_QuestionViewModel();
                        Data.Id = Convert.ToInt32(dr["Id"]);
                        Data.CM_question_id = (Guid)dr["CM_question_id"];
                        Data.CM_question = dr["CM_question"].ToString();
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



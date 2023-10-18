
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
    public class CM_outputDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public CM_outputDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }



        //------------------------------------------------------------------前台-------------------------------------------------------------------------------------
        #region 新增症狀button
        public string NewCM_output(NewCM_OutputViewModel value,Guid user_id)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string sql = $@"INSERT INTO CM_output
                            (CM_output_id,user_id,CM_output_date,CM_output_options,CM_type_id,isdel,create_id,create_time,update_id,update_time) 
                            VALUES (@CM_Output_id,@user_id,@CM_output_date,@CM_output_options,@CM_type_id,@isdel,@create_id,@create_time,@update_id,@update_time)";
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@CM_output_id ", Guid.NewGuid());
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.Parameters.AddWithValue("@CM_output_date", DateTime.Now);
                    command.Parameters.AddWithValue("@CM_output_options ", value.CM_output_options);
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

        #region 總覽中藥診斷(要測試)

        public List<CM_OutputViewModel> GetCM_Output(Guid user_id)
        {
            string sql = "SELECT * FROM CM_output WHERE isdel = 'false' AND user_id = @user_id";
            List<CM_OutputViewModel> DataList = new List<CM_OutputViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@user_id", user_id);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CM_OutputViewModel Data = new CM_OutputViewModel();
                      
                        Data.CM_output_id = (Guid)reader["CM_output_id"];
                        Data.CM_output_options = reader["CM_output_options"].ToString();
                        Data.CM_type_id = Convert.ToInt32(reader["CM_type_id"]);
                        Data.CM_output_date = Convert.ToDateTime(reader["CM_output_date"]);
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



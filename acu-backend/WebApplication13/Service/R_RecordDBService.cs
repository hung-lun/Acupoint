
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
    public class R_RecordDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public R_RecordDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }

        #region 新增復健紀錄
        public string NewR_record(Guid acupuncture_points_id, Guid user_id)
        {
            string userCountQuery = $@"SELECT COUNT(*) AS COUNT FROM ""user"" WHERE ""user_id"" = @user_id AND user_start = '1'";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = $@"INSERT INTO R_record
                        (R_record_id,user_id,R_record_date,acupuncture_points_id,R_record_finish,isdel,create_id,create_time,update_id,update_time) 
                        VALUES (@R_record_id,@R_record_date,@acupuncture_points_id,@R_record_finish,@isdel,@create_id,@create_time,@update_id,@update_time)";
            SqlCommand userCountCmd = new SqlCommand(userCountQuery, conn);
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                conn.Open();

                userCountCmd.Parameters.AddWithValue("@user_id", user_id);
                int userCount = (int)userCountCmd.ExecuteScalar();

                if (userCount <= 0)
                {
                    return "使用者不存在";
                }

                command.Parameters.AddWithValue("@R_record_id", Guid.NewGuid());
                command.Parameters.AddWithValue("@user_id", user_id);
                command.Parameters.AddWithValue("@R_record_date", DateTime.Now);
                command.Parameters.AddWithValue("@acupuncture_points_id", acupuncture_points_id);
                command.Parameters.AddWithValue("@R_record_finish", 1);

                command.Parameters.AddWithValue("@isdel", 0);
                command.Parameters.AddWithValue("@create_id", "Admin");
                command.Parameters.AddWithValue("@create_time", DateTime.Now);
                command.Parameters.AddWithValue("@update_id", "Admin");
                command.Parameters.AddWithValue("@update_time", DateTime.Now);
                int num = command.ExecuteNonQuery();
                if (num > 0)
                {
                    return "已完成！";
                }
                else
                {
                    return "未完成，請重試！";
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

        #region 總覽復健紀錄
        public List<GetR_RecordViewModel> GetR_record(Guid user_id, DateTime R_record_date)
        {
            //string Sql = $@"SELECT * FROM R_record where ""user_id""='{user_id}' and R_record_date={R_record_date} ";
            string Sql = $@" SELECT R_record.*, acupuncture_points.*
                                FROM R_record
                                INNER JOIN acupuncture_points ON R_record.acupuncture_points_id = acupuncture_points.acupuncture_points_id
                                WHERE R_record.user_id = '{user_id}' AND R_record.R_record_date = '{R_record_date}'";
            //string Sql = "SELECT * FROM Eye_question where isdel='false'  ";
            List<GetR_RecordViewModel> DataList = new List<GetR_RecordViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetR_RecordViewModel Data = new GetR_RecordViewModel();

                        Data.acupuncture_points_id = (Guid)(reader["acupuncture_points_id"]);
                        Data.acupuncture_points_name = reader["acupuncture_points_name"].ToString();
                        Data.R_record_finish = Convert.ToInt32(reader["R_record_finish"]);
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



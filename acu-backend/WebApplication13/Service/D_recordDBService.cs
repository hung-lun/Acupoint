
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

        public D_recordDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }
        #region 診斷
        public ShowDiagnosticsViewModel ShowDiagnostics(string Id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            ShowDiagnosticsViewModel Data = new ShowDiagnosticsViewModel();
            string sql = $@" select * from eye_question where Eye_question_id =@eye_question_id ";
        
            try
            {
                
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@eye_question_id", Id);
                command.ExecuteNonQuery();
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                Data.eye_question_id = dr["eye_question_id"].ToString();
                Data.eye_question_content = dr["eye_question_content"].ToString();
                //Data.isdel = Convert.ToBoolean(dr["isdel"]);

            }
            catch (Exception e)
            {
            
                Data = null;
            }
            finally
            {
               
                conn.Close();
            }
        
            return Data;
        }
        #endregion

    }
}




using WebApplication13.Service;
using System.Data.SqlClient;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication13.Model;
using WebApplication13.Controllers;
using System.Linq;
using WebApplication13.ViewModel;
using System.Security.Principal;
using System;
using System.Reflection.PortableExecutable;

namespace WebApplication13.Service
{
    public class Chinese_MedicineDBService
    {
        private readonly UserDBService _userService;
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public Chinese_MedicineDBService(UserDBService userdbService, IConfiguration Configuration)
        {
            _userService = userdbService;
            configuration = Configuration;
            connectionString = configuration.GetConnectionString("Local");

        }
        #region 新增中藥
        public string NewChinese_Medicine(Chinese_MedicineViewModel value)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            string sql = $@"INSERT INTO Chinese_Medicine
                        (chinese_medicine_id,chinese_medicine_name,chinese_medicine_taboo,chinese_medicinal_materials,chinese_medicinal_effect,chinese_medicinal_main,chinese_medicinal_explain,chinese_medicinal_other,CM_type_id,isdel,create_id,create_time,update_id,update_time) 
                        VALUES (@chinese_medicine_id,@chinese_medicine_name,@chinese_medicine_taboo,@chinese_medicinal_materials,@chinese_medicinal_effect,@chinese_medicinal_main,@chinese_medicinal_explain,@chinese_medicinal_other,@CM_type_id,@isdel,@create_id,@create_time,@update_id,@update_time)";

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@chinese_medicine_id", Guid.NewGuid());
                command.Parameters.AddWithValue("@chinese_medicine_name", value.chinese_medicine_name);
                command.Parameters.AddWithValue("@chinese_medicine_taboo", value.chinese_medicine_taboo);
                command.Parameters.AddWithValue("@chinese_medicinal_materials", value.chinese_medicinal_materials);
                command.Parameters.AddWithValue("@chinese_medicinal_effect", value.chinese_medicinal_effect);
                command.Parameters.AddWithValue("@chinese_medicinal_main", value.chinese_medicinal_main);
                command.Parameters.AddWithValue("@chinese_medicinal_explain", value.chinese_medicinal_explain);
                command.Parameters.AddWithValue("@chinese_medicinal_other", value.chinese_medicinal_other);
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
        #endregion

        #region 修改中藥
        public string PutChinese_Medicine(UpdateChinese_MedicineViewModel value)
        {
            string sql = $@"UPDATE Chinese_Medicine SET chinese_medicine_name=@chinese_medicine_name,chinese_medicine_taboo=@chinese_medicine_taboo,chinese_medicinal_materials=@chinese_medicinal_materials,chinese_medicinal_effect=@chinese_medicinal_effect,chinese_medicinal_main=@chinese_medicinal_main,chinese_medicinal_explain=@chinese_medicinal_explain,chinese_medicinal_other=@chinese_medicinal_other,CM_type_id=@CM_type_id,update_id=@update_id,update_time=@update_time WHERE chinese_medicine_id = @chinese_medicine_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@chinese_medicine_id", value.chinese_medicine_id);
                    command.Parameters.AddWithValue("@chinese_medicine_name", value.chinese_medicine_name);
                    command.Parameters.AddWithValue("@chinese_medicine_taboo", value.chinese_medicine_taboo);
                    command.Parameters.AddWithValue("@chinese_medicinal_materials", value.chinese_medicinal_materials);
                    command.Parameters.AddWithValue("@chinese_medicinal_effect", value.chinese_medicinal_effect);
                    command.Parameters.AddWithValue("@chinese_medicinal_main", value.chinese_medicinal_main);
                    command.Parameters.AddWithValue("@chinese_medicinal_explain", value.chinese_medicinal_explain);
                    command.Parameters.AddWithValue("@chinese_medicinal_other", value.chinese_medicinal_other);
                    command.Parameters.AddWithValue("@CM_type_id", value.CM_type_id);
                    command.Parameters.AddWithValue("@update_id", "Admin");
                    command.Parameters.AddWithValue("@update_time", DateTime.Now);
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

        #region 刪除中藥
        public string DeleteChinese_Medicine(string chinese_medicine_id)
        {
            string sql = $@"  UPDATE Chinese_Medicine SET isdel=@isdel WHERE chinese_medicine_id = @chinese_medicine_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@isdel", '1');
                    command.Parameters.AddWithValue("@chinese_medicine_id", chinese_medicine_id);
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
        //------------------------------------------------------------------前台-------------------------------------------------------------------------------------

        #region 總覽中藥食療(要測試)

        public List<GetChinese_MedicineViewModel> GetChinese_Medicine()
        {
            string Sql = "SELECT * FROM Chinese_Medicine where isdel='false'   ORDER BY Id  ASC";
            List<GetChinese_MedicineViewModel> DataList = new List<GetChinese_MedicineViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetChinese_MedicineViewModel Data = new GetChinese_MedicineViewModel();
                        Data.Id = Convert.ToInt32(reader["Id"]);
                        Data.chinese_medicine_id = (Guid)reader["chinese_medicine_id"];
                        Data.chinese_medicine_name = reader["chinese_medicine_name"].ToString();
                        Data.chinese_medicine_taboo = reader["chinese_medicine_taboo"].ToString();
                        Data.chinese_medicinal_materials = reader["chinese_medicinal_materials"].ToString();
                        Data.chinese_medicinal_effect = reader["chinese_medicinal_effect"].ToString();
                        Data.chinese_medicinal_main = reader["chinese_medicinal_main"].ToString();
                        Data.chinese_medicinal_explain = reader["chinese_medicinal_explain"].ToString();
                        Data.chinese_medicinal_other = reader["chinese_medicinal_other"].ToString();

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
        #region 查詢中藥名稱

        public List<GetChinese_MedicineNameViewModel> GetChinese_Medicine_name(Guid chinese_medicine_id)
        {
         
            string sql = "SELECT * FROM Chinese_Medicine WHERE isdel = 'false' AND chinese_medicine_id = @chinese_medicine_id";
            List<GetChinese_MedicineNameViewModel> DataList = new List<GetChinese_MedicineNameViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@chinese_medicine_id", chinese_medicine_id);
                try
                {
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        GetChinese_MedicineNameViewModel Data = new GetChinese_MedicineNameViewModel();
                      
                        Data.chinese_medicine_name = dr["chinese_medicine_name"].ToString();
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
        #region 單筆中藥資訊(要測試)

        public List<GetChinese_Medicine_InformationViewModel> GetChinese_Medicine_Information(Guid chinese_medicine_id)
        {

            string Sql = string.Empty;
            if (chinese_medicine_id != Guid.Empty)
            {
                Sql = "SELECT * FROM Chinese_Medicine where chinese_medicine_id=@chinese_medicine_id and isdel='false'";
            }
            else
            {
                Sql = "SELECT * FROM Chinese_Medicine where isdel='false'";
            }
            var img = "";
            List<GetChinese_Medicine_InformationViewModel> DataList = new List<GetChinese_Medicine_InformationViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                if (chinese_medicine_id != Guid.Empty)
                {
                    command.Parameters.AddWithValue("@chinese_medicine_id", chinese_medicine_id);
                }
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    GetChinese_Medicine_InformationViewModel Data = new GetChinese_Medicine_InformationViewModel();
                   
                    Data.chinese_medicinal_materials = reader["chinese_medicinal_materials"].ToString();
                    Data.chinese_medicinal_effect = reader["chinese_medicinal_effect"].ToString();
                    Data.chinese_medicinal_main = reader["chinese_medicinal_main"].ToString();
                    Data.chinese_medicinal_explain = reader["chinese_medicinal_explain"].ToString();
                    Data.chinese_medicinal_other = reader["chinese_medicinal_other"].ToString();
                    DataList.Add(Data);

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
        #region 判斷中藥類型&計算總分數
        public List<GetChinese_Medicine_TypeViewModel> GetChinese_Medicine_Typescore(Guid user_id)
        {
           
            List<GetChinese_Medicine_TypeViewModel> DataList = new List<GetChinese_Medicine_TypeViewModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string score_sql = $@"SELECT SUM(D_record.D_record_score) * 25 / 15 AS TotalScore FROM D_Record WHERE user_id = @user_id";
                    SqlCommand score_cmd = new SqlCommand(score_sql, conn);
                    score_cmd.Parameters.AddWithValue("@user_id", user_id);
                    int totalScore = (int)score_cmd.ExecuteScalar();

                    string cmType_sql = $@"
                    SELECT CM_output.CM_type_id, COUNT(*) AS Count
                    FROM CM_output
                    INNER JOIN ""user"" ON CM_output.user_id = ""user"".user_id
                    WHERE ""user"".user_id = @user_id
                    GROUP BY CM_output.CM_type_id
                    ORDER BY COUNT(*) DESC
                    LIMIT 1";

                    SqlCommand cmType_cmd = new SqlCommand(cmType_sql, conn);
                    cmType_cmd.Parameters.AddWithValue("@user_id", user_id);
                    SqlDataReader reader = cmType_cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetChinese_Medicine_TypeViewModel Data = new GetChinese_Medicine_TypeViewModel();
                        Data.CM_type_id = Convert.ToInt32(reader["CM_type_id"]);
                        Data.CM_type_name = reader["CM_type_name"].ToString();
                        Data.TotalScore = totalScore;
                        DataList.Add(Data);
                    }
                        return DataList;
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






    }
}



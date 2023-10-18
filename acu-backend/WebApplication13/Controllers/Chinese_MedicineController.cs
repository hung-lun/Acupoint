using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Principal;
using WebApplication13.Model;
using WebApplication13.Security;
using WebApplication13.Service;
using WebApplication13.ViewModel;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chinese_MedicineController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly Chinese_MedicineDBService _chinese_MedicineService;
        public Chinese_MedicineController(UserDBService userService, IConfiguration config, Chinese_MedicineDBService chinese_MedicineService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _chinese_MedicineService = chinese_MedicineService;
        }

        #region 新增中醫資訊

        [HttpPost]
        [Route("NewChinese_Medicine")]
        public IActionResult NewChinese_Medicine(Chinese_MedicineViewModel value)
        {
            var result = _chinese_MedicineService.NewChinese_Medicine(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);

        }
        #endregion
        #region 修改中醫資訊
        [HttpPut]
        [Route("PutChinese_Medicine/")]
        public IActionResult PutChinese_Medicine(UpdateChinese_MedicineViewModel value)
        {
            var result = _chinese_MedicineService.PutChinese_Medicine(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion

        #region 刪除中醫資訊
        [HttpDelete]
        [Route("DeleteChinese_Medicine/{chinese_medicine_id}")]

        public IActionResult DeleteChinese_Medicine([FromRoute] string chinese_medicine_id)
        {
            string result = _chinese_MedicineService.DeleteChinese_Medicine(chinese_medicine_id);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion
      
        ///-------------------------------------------------------------------前台--------------------------------------------------
         #region 總覽中藥食療
        [HttpGet]
        [Route("GetAcupuncture_Points")]
        public IActionResult GetAcupuncture_Points()
        {
            var result = _chinese_MedicineService.GetChinese_Medicine();
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion
        #region 中藥名稱
        [HttpGet]
        [Route("GetChinese_Medicine_name")]
        public IActionResult GetChinese_Medicine_name(Guid chinese_medicine_id)
        {
            var result = _chinese_MedicineService.GetChinese_Medicine_name(chinese_medicine_id);
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion

        #region 總覽個別穴位資訊
        [HttpGet]
        [Route("GetChinese_Medicine_Information")]
        public IActionResult GetChinese_Medicine_Information(Guid chinese_medicine_id)
        {
            var result = _chinese_MedicineService.GetChinese_Medicine_Information(chinese_medicine_id);
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion
                #region 中藥類型&總分數
                [HttpGet]
                [Route("GetChinese_Medicine_Typescore")]
                public IActionResult GetChinese_Medicine_Typescore(Guid user_id)
                {
                    var result = _chinese_MedicineService.GetChinese_Medicine_Typescore(user_id);
                    if (result == null || result.Count <= 0)
                    {
                        return NotFound("找不到資源");
                    }
                    return Ok(result);
                }
        #endregion

    }
}

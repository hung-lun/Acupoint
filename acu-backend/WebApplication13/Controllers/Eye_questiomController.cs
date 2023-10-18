using Castle.Core.Smtp;
using DI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class Eye_questionController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly Eye_questionDBService _eye_questionService;
        public Eye_questionController(UserDBService userService, IConfiguration config, Eye_questionDBService eye_questionService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _eye_questionService = eye_questionService;
        }

#region 新增檢測題目

        [HttpPost]
        [Route("NewQuestion")]
        public IActionResult NewQuestion(Eye_questionViewModel value)
        {
            var result = _eye_questionService.NewQuestion(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);

        }
#endregion
        #region 修改檢測題目
        [HttpPut]
        [Route("PutEye_Question/{eye_question_id}/{eye_question_content}")]
        public IActionResult PutEye_Question([FromRoute] GetEye_questionViewModel value)
        {
            var result = _eye_questionService.PutEye_Question(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion

        #region 刪除檢測題目
        [HttpDelete]
        [Route("DeleteEye_Question/{eye_question_id}")]

        public IActionResult DeleteEye_Question([FromRoute] string eye_question_id)
        {
            string result = _eye_questionService.DeleteEye_Question(eye_question_id);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion

        ///-------------------------------------------------------------------前台--------------------------------------------------
        /// <summary>
        /// 總攬問題
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestion")]
        public IActionResult GetQuestion()
        {
            var result = _eye_questionService.GetQuestion();
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }



    }
}

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
    public class CM_questionController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly CM_questionDBService _cm_questionService;
        public CM_questionController(UserDBService userService, IConfiguration config, CM_questionDBService cm_questionService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _cm_questionService = cm_questionService;
        }
        #region 新增症狀button

        [HttpPost]
        [Route("NewGetCM_Question_Button")]//(要修改)
        public IActionResult NewGetCM_Question_Button(CM_QuestionViewModel value)
        {
            var result = _cm_questionService.NewGetCM_Question_Button(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);

        }
        #endregion

        ///-------------------------------------------------------------------前台--------------------------------------------------
     


        #region 總覽症狀button
        [HttpGet]
        [Route("GetCM_Question_Button")]
        public IActionResult GetCM_Question_Button()
        {
            var result = _cm_questionService.GetCM_Question_Button();
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion


    }
}

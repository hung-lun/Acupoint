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
    public class CM_outputController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly CM_outputDBService _cm_outputService ;
        public CM_outputController(UserDBService userService, IConfiguration config, CM_outputDBService cm_outputService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _cm_outputService = cm_outputService;
        }


        ///-------------------------------------------------------------------前台--------------------------------------------------

        #region 新增點選症狀button

        [HttpPost]
        [Route("NewCM_output ")]
        public IActionResult NewCM_output(NewCM_OutputViewModel value, Guid user_id)
        {
            var result = _cm_outputService.NewCM_output(value, user_id);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
          
        }
        #endregion

        #region  總覽中藥診斷(要測試)
        [HttpGet]
        [Route("GetCM_Output")]
        public IActionResult GetCM_Output(Guid user_id)
        {
            var result = _cm_outputService.GetCM_Output(user_id);
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion


    }
}

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
    public class ForgetPwdController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly ForgetPwdDBService _forgetPwdService;


        public ForgetPwdController(UserDBService userService, IConfiguration config, ForgetPwdDBService forgetPwdService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _forgetPwdService = forgetPwdService;

        }


        #region 發送email
        [HttpGet]
        [Route("ForgetPwd/Send_email")]
        public IActionResult Forget_pwd(string Account)
        {
            var result = _forgetPwdService.forget_pwd(Account);

            if (result == null)
            {
                return NotFound("找不到資源");
            }
            else if (result == 0)
            {
                return Ok("資料庫未有此信箱");
            }
            else if (result == 1)
            {
                return Ok("已發送驗證碼");
            }
            return Ok(result);
        }
        #endregion

        #region 驗證驗證碼
        [HttpPost]
        [Route("verify_cord")]
        public IActionResult forget_pwd_code([FromBody] ForgotPasswordViewModel Member)
        {
            var result = _forgetPwdService.forget_pwd_code(Member.user_account, Member.user_authcode);
            var result1 = _forgetPwdService.upd_pwd(Member.user_account, Member.New_Pwd);
            if (result == null && result1 == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion


    }
}

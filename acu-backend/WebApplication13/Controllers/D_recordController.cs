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
    public class D_recordController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly ForgetPwdDBService _forgetPwdService;
        private readonly D_recordDBService _d_recordDBService;
        private readonly Eye_questionDBService _eye_questionDBService;


        public D_recordController(UserDBService userService, IConfiguration config, ForgetPwdDBService forgetPwdService, D_recordDBService d_recordDBService,Eye_questionDBService eye_questionDBService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _forgetPwdService = forgetPwdService;
            _d_recordDBService = d_recordDBService;
            _eye_questionDBService= eye_questionDBService;
        }
        #region

        [HttpGet]
        public IActionResult ShowDiagnostics( Eye_questionViewModel value)
        {
            var result = _eye_questionDBService.ShowDiagnostics(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
       
        }
        #endregion
       

    }
}

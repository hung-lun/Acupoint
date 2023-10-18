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
    public class R_recordController : ControllerBase
    {

       
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly R_RecordDBService  _r_recordDBService;
    


        public R_recordController(IConfiguration config, R_RecordDBService r_recordDBService)
        {
        
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _r_recordDBService = r_recordDBService;
       
        }

        #region 新增復健紀錄

        [HttpPost]
        [Route("NewR_record")]
        public IActionResult NewR_record(Guid acupuncture_points_id, Guid user_id)
        {
            var result = _r_recordDBService.NewR_record( acupuncture_points_id,  user_id);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);

        }
        #endregion

        #region 總覽復健紀錄

        [HttpGet]
        [Route("GetR_record")]
        public IActionResult GetR_record(Guid user_id,DateTime R_record_date)
        {
            var result = _r_recordDBService.GetR_record(user_id, R_record_date);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);

        }
        #endregion


    }
}

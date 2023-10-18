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
    public class Acupuncture_PointsController : ControllerBase
    {

        private readonly UserDBService _userService;
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly Acupuncture_PointsDBService  _acupuncture_pointsService;
        public Acupuncture_PointsController(UserDBService userService, IConfiguration config, Acupuncture_PointsDBService acupuncture_pointsService)
        {

            _userService = userService;
            _config = config;
            connectionString = _config.GetConnectionString("Local");
            _acupuncture_pointsService = acupuncture_pointsService;
        }


        #region 新增穴位資訊

        [HttpPost]
        [Route("NewAcupuncture_Points")]
        public IActionResult NewAcupuncture_Points(Acupuncture_PointsViewModel value)
        {
            var result = _acupuncture_pointsService.NewAcupuncture_Points(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);

        }
        #endregion


        #region 修改穴位資訊
        [HttpPut]
        [Route("PutAcupuncture_Points")]
        public IActionResult PutAcupuncture_Points(UpdateAcupuncture_PointsViewModel value)
        {
            var result = _acupuncture_pointsService.PutAcupuncture_Points(value);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion

        #region 刪除穴位資訊
        [HttpDelete]
        [Route("DeleteAcupuncture_Points/{acupuncture_points_id}")]

        public IActionResult DeleteAcupuncture_Points([FromRoute] string acupuncture_points_id)
        {
            string result = _acupuncture_pointsService.DeleteAcupuncture_Points(acupuncture_points_id);
            if (result == null)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion

        ///-------------------------------------------------------------------前台--------------------------------------------------
    
        #region 總覽穴位名稱
        [HttpGet]
        [Route("GetAcupuncture_PointsName")]
        public IActionResult GetAcupuncture_PointsName()
        {
            var result = _acupuncture_pointsService.GetAcupuncture_PointsName();
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion



        #region 總覽個別穴位資訊
        [HttpGet]
        [Route("GetAcupuncture_Points")]
        public IActionResult GetAcupuncture_Points(Guid acupuncture_points_id)
        {
            var result = _acupuncture_pointsService.GetAcupuncture_Points(acupuncture_points_id);
            if (result == null || result.Count <= 0)
            {
                return NotFound("找不到資源");
            }
            return Ok(result);
        }
        #endregion
    }
}

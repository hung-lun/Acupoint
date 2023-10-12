using Jose;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using WebApplication13.Model;

namespace WebApplication13.Security
{
    public class JwtService
    {
        #region 製作 Token 
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;
        public JwtService(IConfiguration config,IHttpContextAccessor contextAccessor)
        {
            _config = config;
           _contextAccessor= contextAccessor;
        }

        public string GenerateToken(string Account, string Role)
        {
            //資料填進jwtObject裡
            JwtObject jwtObject = new JwtObject
            {
          
                user_account = Account,
                Role = Role,
                Expire = DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:ExpireMinutes"])).ToString()
            };
            // 將資料塞進 Claim 內做設計
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,Account),
              
            };
            // 將使用者角色資料取出，並分割成陣列
            string[] roles=jwtObject.Role.Split(',');
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
               
            }
           
            //製作金鑰
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:SecretKey")));
 
            //製作數位簽章
            var cred =new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
            //JWT的身分驗證跟授權資訊的
            var token = new JwtSecurityToken(
                claims : claims,
                expires : DateTime.Now.AddHours(1),
                signingCredentials : cred
                

                );





            //將token轉為jwt字串
            var jwt =new JwtSecurityTokenHandler().WriteToken(token);

          
            return jwt;
        }
        #endregion

        public string f(string ID,string Account)
        {
            JwtObject jwtObject = new JwtObject
            {
   
                user_account = Account,
                //Role = Role,
                Expire = DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:ExpireMinutes"])).ToString()
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:SecretKey")));

            var tokenHandler = new JwtSecurityTokenHandler();

            // 將使用者角色資料取出，並分割成陣列
            // 將資料塞進 Claim 內做設計
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,Account),
                 new Claim(ClaimTypes.NameIdentifier, ID.ToString())
            };
            // 將使用者角色資料取出，並分割成陣列
            //string[] roles = jwtObject.Role.Split(',');
            //foreach (string role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
              
            //}
            var tokenDescriptor = new SecurityTokenDescriptor
            {


                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
      

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
        



    }

}

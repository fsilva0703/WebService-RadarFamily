using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("admin/[controller]")]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService paramLoginService)
        {
            _loginService = paramLoginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("GetLogin")]
        public async Task<IActionResult> GetLogin([FromBody] DtoLogin dadosLogin)
        {
            var item = await _loginService.GetLogin(dadosLogin.Login, dadosLogin.Password);
            if (item == null)
            {
                return BadRequest("Login ou senha são inválidos");
            }
            return Ok(item);
        }
    }
}
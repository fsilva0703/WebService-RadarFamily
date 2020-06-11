using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily.Controllers.admin
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("admin/[controller]")]
    public class PositionController : Controller
    {
        private IPositionService _positionService;

        public PositionController(IPositionService paramPositionService)
        {
            _positionService = paramPositionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("SetLastPosition")]
        public IActionResult SetLastPosition([FromBody] DtoPosition paramPosition)
        {
            DtoPosition pos = new DtoPosition();
            
            pos = _positionService.SetLastPosition(paramPosition);
            _positionService.SetPosition(pos);
            
            return Json(pos);
        }
        
        [HttpGet, Route("GetLastPosition")]
        public IActionResult GetLastPosition(Int32 paramIdUnidadeRastreada)
        {
            List<DtoPosition> pos = new List<DtoPosition>();
            
            pos = _positionService.GetLastPosition(paramIdUnidadeRastreada);
            
            return Json(pos);
        }

        [HttpGet, Route("GetHistoricPositionByData")]
        public IActionResult GetHistoricPosition(DateTime paramDataIni, DateTime paramDataFim)
        {
            List<DtoPosition> pos = new List<DtoPosition>();

            pos = _positionService.GetHistoricPosition(paramDataIni, paramDataFim);

            return Json(pos);
        }

        [HttpGet, Route("GetHistoricPosition")]
        public IActionResult GetHistoricPosition(Int32 paramIdUnidadeRastreada, DateTime paramDataIni, DateTime paramDataFim)
        {
            List<DtoPosition> pos = new List<DtoPosition>();

            pos = _positionService.GetHistoricPosition(paramIdUnidadeRastreada, paramDataIni, paramDataFim);

            return Json(pos);
        }

    }
}
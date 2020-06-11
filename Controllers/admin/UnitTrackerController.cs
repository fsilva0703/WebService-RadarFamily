using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Models.Dto.Common;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily.Controllers.admin
{

    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("admin/[controller]")]
    public class UnitTrackerController : Controller
    {

        private IUnitTrackerService _unitTrackerService;

        public UnitTrackerController(IUnitTrackerService paramUnitTrackerService)
        {
            _unitTrackerService = paramUnitTrackerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("GetUnitTrackerByAdmin")]
        public IActionResult GetListUnitTracker(Int32 paramIdAdmin)
        {
            List<DtoUnitTracker> UnitTracker = new List<DtoUnitTracker>();

            UnitTracker = _unitTrackerService.GetListUnitTracker(paramIdAdmin);

            return Json(UnitTracker);
        }

        [HttpGet, Route("GetUnitTrackerById")]
        public IActionResult GetUnitTracker(Int32 paramIdUnitTracker)
        {
            DtoUnitTracker UnitTracker = new DtoUnitTracker();

            UnitTracker = _unitTrackerService.GetUnitTracker(paramIdUnitTracker);

            return Json(UnitTracker);
        }

        [HttpPost, Route("Update")]
        public IActionResult Update([FromBody] DtoUnitTracker paramUnitTracker)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result = _unitTrackerService.Update(paramUnitTracker);

            if (!result.Data)
            {
                return BadRequest("Este login não pode ser utilizado, pois já existe no sistema.");
            }
            return Ok(result.Data);
        }

        [HttpPost, Route("Insert")]
        public IActionResult Insert([FromBody] DtoUnitTracker paramUnitTracker)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result = _unitTrackerService.Insert(paramUnitTracker);

            if (!result.Data)
            {
                return BadRequest("Este login não pode ser utilizado, pois já existe no sistema.");
            }
            return Ok(result.Data);
        }

        [HttpGet, Route("GetAvatar")]
        public IActionResult GetAvatar()
        {
            List<DtoAvatar> avatar = new List<DtoAvatar>();

            avatar = _unitTrackerService.GetAvatar();

            return Json(avatar);
        }

    }
}
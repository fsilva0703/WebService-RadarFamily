using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Models.Dto.Common;

namespace WS_RadarFamily.Service.Interface
{
    public interface IUnitTrackerService
    {
        List<DtoUnitTracker> GetListUnitTracker(Int32 paramIdAdmin);
        DtoUnitTracker GetUnitTracker(Int32 paramIdUnitTracker);
        ServiceResult<Boolean> Update(DtoUnitTracker paramUnitTracker);
        ServiceResult<Boolean> Insert(DtoUnitTracker paramUnitTracker);
        List<DtoAvatar> GetAvatar();
    }
}

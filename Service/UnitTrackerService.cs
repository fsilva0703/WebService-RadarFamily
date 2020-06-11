using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Models.Dto.Common;
using WS_RadarFamily.Repository.Interface;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily.Service
{
    public class UnitTrackerService : IUnitTrackerService
    {
        private readonly IUnitTrackerRepository _unitTrackerRepository;
        public UnitTrackerService(IUnitTrackerRepository paramUnitTrackerRepository)
        {
            _unitTrackerRepository = paramUnitTrackerRepository;
        }
        public List<DtoUnitTracker> GetListUnitTracker(Int32 paramIdAdmin)
        {
            List<DtoUnitTracker> unitTracker = new List<DtoUnitTracker>();
            unitTracker = _unitTrackerRepository.GetListUnitTracker(paramIdAdmin);

            return unitTracker;
        }

        public DtoUnitTracker GetUnitTracker(Int32 paramUnitTracker)
        {
            DtoUnitTracker unitTracker = new DtoUnitTracker();
            unitTracker = _unitTrackerRepository.GetUnitTracker(paramUnitTracker);

            return unitTracker;
        }

        public ServiceResult<Boolean> Update(DtoUnitTracker paramUnitTracker)
        {
            ServiceResult<Boolean> unitTracker = new ServiceResult<Boolean>();
            unitTracker = _unitTrackerRepository.Update(paramUnitTracker);

            return unitTracker;
        }

        public ServiceResult<Boolean> Insert(DtoUnitTracker paramUnitTracker)
        {
            ServiceResult<Boolean> unitTracker = new ServiceResult<Boolean>();
            unitTracker = _unitTrackerRepository.Insert(paramUnitTracker);

            return unitTracker;
        }

        public List<DtoAvatar> GetAvatar()
        {
            List<DtoAvatar> avatar = new List<DtoAvatar>();
            avatar = _unitTrackerRepository.GetAvatar();

            return avatar;
        }
    }
}

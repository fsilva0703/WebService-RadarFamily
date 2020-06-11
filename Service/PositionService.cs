using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Repository.Interface;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily.Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository paramPositionRepository)
        {
            _positionRepository = paramPositionRepository;
        }
        public DtoPosition SetLastPosition(DtoPosition paramPosition)
        {
            DtoPosition pos = new DtoPosition();
            pos = _positionRepository.SetLastPosition(paramPosition);

            return pos;
        }

        public void SetPosition(DtoPosition paramPosition)
        {
            _positionRepository.SetPosition(paramPosition);
        }

        public List<DtoPosition> GetLastPosition(Int32 paramIdUnidadeRastreada)
        {
            List<DtoPosition> pos = new List<DtoPosition>();
            pos = _positionRepository.GetLastPosition(paramIdUnidadeRastreada);

            return pos;
        }

        public List<DtoPosition> GetHistoricPosition(DateTime paramDataIni, DateTime paramDataFim)
        {
            List<DtoPosition> pos = new List<DtoPosition>();
            pos = _positionRepository.GetHistoricPosition(paramDataIni, paramDataFim);

            return pos;
        }

        public List<DtoPosition> GetHistoricPosition(Int32 paramIdUnidadeRastreada, DateTime paramDataIni, DateTime paramDataFim)
        {
            List<DtoPosition> pos = new List<DtoPosition>();
            pos = _positionRepository.GetHistoricPosition(paramIdUnidadeRastreada, paramDataIni, paramDataFim);

            return pos;
        }

    }
}

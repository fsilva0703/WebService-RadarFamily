using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;

namespace WS_RadarFamily.Repository.Interface
{
    public interface IPositionRepository
    {
        void SetPosition(DtoPosition paramPosition);
        DtoPosition SetLastPosition(DtoPosition paramPosition);
        List<DtoPosition> GetLastPosition(Int32 paramIdUnidadeRastreada);
        List<DtoPosition> GetHistoricPosition(DateTime paramDataIni, DateTime paramDataFim);
        List<DtoPosition> GetHistoricPosition(Int32 paramIdUnidadeRastreada, DateTime paramDataIni, DateTime paramDataFim);
    }
}

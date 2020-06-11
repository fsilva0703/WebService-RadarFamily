using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;

namespace WS_RadarFamily.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<DtoResultLogin> GetLogin(String Login, String Password);
    }
}

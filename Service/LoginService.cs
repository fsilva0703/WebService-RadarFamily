using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Repository.Interface;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository paramLoginRepository)
        {
            _loginRepository = paramLoginRepository;
        }

        public async Task<DtoResultLogin> GetLogin(String Login, String Password)
        {
            try
            {
                Task<DtoResultLogin> lst = null;
                lst = _loginRepository.GetLogin(Login, Password);
                return await lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Models.Dto.Common;
using WS_RadarFamily.Repository.Interface;

namespace WS_RadarFamily.Repository
{
    public class UnitTrackerRepository : IUnitTrackerRepository
    {
        private readonly IConfiguration _configuration;
        public UnitTrackerRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("RadarFamily");
            return conString;
        }

        public List<DtoUnitTracker> GetListUnitTracker(Int32 paramIdAdmin)
        {

            try
            {
                List<DtoUnitTracker> listUr = new List<DtoUnitTracker>();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_getListUnitTracker]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmIdAdmin", paramIdAdmin);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        DtoUnitTracker item = new DtoUnitTracker();
                        if (!sqlDataReader.IsDBNull(0)) item.IdUser = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.Name = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(2)) item.Login = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) item.CalculoDistancia = sqlDataReader.GetInt32(3);
                        if (!sqlDataReader.IsDBNull(4)) item.CreatedDate = sqlDataReader.GetDateTime(4);
                        if (!sqlDataReader.IsDBNull(5)) item.IntervaloPosicao = sqlDataReader.GetInt32(5);
                        if (!sqlDataReader.IsDBNull(6)) item.Avatar = sqlDataReader.GetString(6);
                        if (!sqlDataReader.IsDBNull(7)) item.IntervaloPosicaoParado = sqlDataReader.GetInt32(7);

                        listUr.Add(item);
                    }

                    return listUr;

                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        public DtoUnitTracker GetUnitTracker(Int32 paramIdUnitTracker)
        {

            try
            {
                DtoUnitTracker unitTracker = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_getUnitTracker]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmIdUnitTracker", paramIdUnitTracker);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        unitTracker = new DtoUnitTracker();
                        if (!sqlDataReader.IsDBNull(0)) unitTracker.IdUser = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) unitTracker.Name = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(2)) unitTracker.Login = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) unitTracker.CalculoDistancia = sqlDataReader.GetInt32(3);
                        if (!sqlDataReader.IsDBNull(4)) unitTracker.CreatedDate = sqlDataReader.GetDateTime(4);
                        if (!sqlDataReader.IsDBNull(5)) unitTracker.IntervaloPosicao = sqlDataReader.GetInt32(5);
                        if (!sqlDataReader.IsDBNull(6)) unitTracker.Avatar = sqlDataReader.GetString(6);
                        if (!sqlDataReader.IsDBNull(7)) unitTracker.IntervaloPosicaoParado = sqlDataReader.GetInt32(7);
                    }

                    return unitTracker;

                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        public ServiceResult<Boolean> Update(DtoUnitTracker paramUnitTracker)
        {

            try
            {
                ServiceResult<Boolean> result = new ServiceResult<Boolean>();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_updateUnitTracker]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmIdUser", paramUnitTracker.IdUser);
                    cmd.Parameters.AddWithValue("@prmName", paramUnitTracker.Name);
                    cmd.Parameters.AddWithValue("@prmLogin", paramUnitTracker.Login);
                    cmd.Parameters.AddWithValue("@prmCalculoDistancia", paramUnitTracker.CalculoDistancia);
                    cmd.Parameters.AddWithValue("@prmIntervaloPosicao", paramUnitTracker.IntervaloPosicao);
                    cmd.Parameters.AddWithValue("@prmIntervaloPosicaoParado", paramUnitTracker.IntervaloPosicaoParado);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.IsDBNull(0)) result.Data = sqlDataReader.GetBoolean(0);
                    }

                    return result;

                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        public ServiceResult<Boolean> Insert(DtoUnitTracker paramUnitTracker)
        {

            try
            {
                ServiceResult<Boolean> result = new ServiceResult<Boolean>();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_insertUnitTracker]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmIdUser", paramUnitTracker.IdUser);
                    cmd.Parameters.AddWithValue("@prmName", paramUnitTracker.Name);
                    cmd.Parameters.AddWithValue("@prmLogin", paramUnitTracker.Login);
                    cmd.Parameters.AddWithValue("@prmCalculoDistancia", paramUnitTracker.CalculoDistancia);
                    cmd.Parameters.AddWithValue("@prmIntervaloPosicao", paramUnitTracker.IntervaloPosicao);
                    cmd.Parameters.AddWithValue("@prmIntervaloPosicaoParado", paramUnitTracker.IntervaloPosicaoParado);
                    cmd.Parameters.AddWithValue("@prmAvatar", paramUnitTracker.Avatar);
                    cmd.Parameters.AddWithValue("@prmIdAdmin", paramUnitTracker.IdAdmin);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        if (!sqlDataReader.IsDBNull(0)) result.Data = sqlDataReader.GetBoolean(0);
                    }

                    return result;

                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        public List<DtoAvatar> GetAvatar()
        {

            try
            {
                List<DtoAvatar> avatar = new List<DtoAvatar>();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_getListAvatar]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        DtoAvatar item = new DtoAvatar();
                        if (!sqlDataReader.IsDBNull(0)) item.idImage = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.Name = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(2)) item.IsAtivo = sqlDataReader.GetBoolean(2);

                        avatar.Add(item);
                    }

                    return avatar;

                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

    }
}

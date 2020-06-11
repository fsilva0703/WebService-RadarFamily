using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WS_RadarFamily.Models.Dto;
using WS_RadarFamily.Repository.Interface;

namespace WS_RadarFamily.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;
        IMongoClient MongoClient = new MongoClient("mongodb+srv://fsilva0703:<password>@cluster0-bw2rh.mongodb.net/test?retryWrites=true&w=majority");

        public LoginRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("RadarFamily");
            return conString;
        }

        public async Task<DtoResultLogin> GetLogin(String Login, String Password)
        {
            try
            {
                DtoResultLogin item = null;
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_getLogin]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmLogin", Login);
                    cmd.Parameters.AddWithValue("@prmPassword", Password);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    if(sqlDataReader.Read())
                    {
                        item = new DtoResultLogin();
                        if (!sqlDataReader.IsDBNull(0)) item.IdUser = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.IdUnidadeRastreada = sqlDataReader.GetInt32(1);
                        if (!sqlDataReader.IsDBNull(2)) item.IdAdmin = sqlDataReader.GetInt32(2);
                        if (!sqlDataReader.IsDBNull(3)) item.Login = sqlDataReader.GetString(3);
                        if (!sqlDataReader.IsDBNull(4)) item.Password = sqlDataReader.GetString(4);
                        if (!sqlDataReader.IsDBNull(5)) item.Nome = sqlDataReader.GetString(5);
                        if (!sqlDataReader.IsDBNull(6)) item.IsAdmin = sqlDataReader.GetBoolean(6);
                        if (!sqlDataReader.IsDBNull(7)) item.CalculoDistancia = sqlDataReader.GetInt32(7);
                        if (!sqlDataReader.IsDBNull(8)) item.IntervaloPosicao = sqlDataReader.GetInt32(8);
                        if (!sqlDataReader.IsDBNull(9)) item.Avatar = sqlDataReader.GetString(9);
                    }

                    con.Close();
                }

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

    }
}

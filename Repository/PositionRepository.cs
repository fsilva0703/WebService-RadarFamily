using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
    public class PositionRepository : IPositionRepository
    {
        private readonly IConfiguration _configuration;
        private UpdateOptions UpdateOptions;
        public PositionRepository(IConfiguration config)
        {
            _configuration = config;

            UpdateOptions = new UpdateOptions();
            UpdateOptions.IsUpsert = true;
        }

        IMongoClient MongoClient = new MongoClient("mongodb+srv://fsilva0703:adm2n262rador@cluster0-bw2rh.mongodb.net/test?retryWrites=true&w=majority");

        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("RadarFamily");
            return conString;
        }

        [Obsolete]
        public void SetPosition(DtoPosition paramPosition)
        {
            IMongoDatabase database = MongoClient.GetDatabase("RadarFamily");
            IMongoCollection<DtoPosition> position = database.GetCollection<DtoPosition>("HistoricoPosicao");

            DtoPosition pos = new DtoPosition();
            pos._id = paramPosition._id;
            pos.IdUnidadeRastreada = paramPosition.IdUnidadeRastreada;
            pos.Name = paramPosition.Name;
            pos.DateEvent = paramPosition.DateEvent;
            pos.DateAtualizacao = paramPosition.DateAtualizacao;
            pos.Address = paramPosition.Address;
            pos.Latitude = paramPosition.Latitude;
            pos.Longitude = paramPosition.Longitude;
            pos.IdRegra = paramPosition.IdRegra;
            pos.Avatar = paramPosition.Avatar;
            try
            {
                position.ReplaceOne(x => x._id == pos._id, pos, UpdateOptions);
            }
            catch(NullReferenceException)
            {
                position.InsertOne(pos);
            }
            
        }

        public DtoPosition SetLastPosition(DtoPosition paramPosition)
        {
            try
            {
                DtoPosition pos = null;
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_setLastPosition]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmIdUnidadeRastreada", paramPosition.IdUnidadeRastreada);
                    cmd.Parameters.AddWithValue("@prmName", paramPosition.Name);
                    cmd.Parameters.AddWithValue("@prmDateEvent", paramPosition.DateEvent);
                    cmd.Parameters.AddWithValue("@prmAddress", paramPosition.Address);
                    cmd.Parameters.AddWithValue("@prmLatitude", paramPosition.Latitude);
                    cmd.Parameters.AddWithValue("@prmLongitude", paramPosition.Longitude);
                    cmd.Parameters.AddWithValue("@prmIdRegra", paramPosition.IdRegra);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        pos = new DtoPosition();
                        if (!sqlDataReader.IsDBNull(0)) pos._id = sqlDataReader.GetInt64(0);
                        if (!sqlDataReader.IsDBNull(1)) pos.IdUnidadeRastreada = sqlDataReader.GetInt32(1);
                        if (!sqlDataReader.IsDBNull(2)) pos.Name = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) pos.DateEvent = sqlDataReader.GetDateTime(3);
                        if (!sqlDataReader.IsDBNull(4)) pos.DateAtualizacao = sqlDataReader.GetDateTime(4);
                        if (!sqlDataReader.IsDBNull(5)) pos.Address = sqlDataReader.GetString(5);
                        if (!sqlDataReader.IsDBNull(6)) pos.Latitude = sqlDataReader.GetDouble(6);
                        if (!sqlDataReader.IsDBNull(7)) pos.Longitude = sqlDataReader.GetDouble(7);
                        if (!sqlDataReader.IsDBNull(8)) pos.IdRegra = sqlDataReader.GetInt32(8);
                        if (!sqlDataReader.IsDBNull(9)) pos.Avatar = sqlDataReader.GetString(9);
                    }

                    con.Close();
                }

                return pos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DtoPosition> GetLastPosition(Int32 paramIdUnidadeRastreada)
        {

            try
            {
                List<DtoPosition> listPos = new List<DtoPosition>();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_getLastPosition]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmIdUnidadeRastreada", paramIdUnidadeRastreada);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        DtoPosition item = new DtoPosition();
                        if (!sqlDataReader.IsDBNull(0)) item._id = sqlDataReader.GetInt64(0);
                        if (!sqlDataReader.IsDBNull(1)) item.IdUnidadeRastreada = sqlDataReader.GetInt32(1);
                        if (!sqlDataReader.IsDBNull(2)) item.Address = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) item.Latitude = sqlDataReader.GetDouble(3);
                        if (!sqlDataReader.IsDBNull(4)) item.Longitude = sqlDataReader.GetDouble(4);
                        if (!sqlDataReader.IsDBNull(5)) item.DateEvent = sqlDataReader.GetDateTime(5);
                        if (!sqlDataReader.IsDBNull(6)) item.DateAtualizacao = sqlDataReader.GetDateTime(6);
                        if (!sqlDataReader.IsDBNull(7)) item.Name = sqlDataReader.GetString(7);
                        if (!sqlDataReader.IsDBNull(8)) item.Avatar = sqlDataReader.GetString(8);

                        listPos.Add(item);
                    }

                    return listPos;

                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        public List<DtoPosition> GetHistoricPosition(DateTime paramDataIni, DateTime paramDataFim)
        {
            IMongoDatabase database = MongoClient.GetDatabase("RadarFamily");
            IMongoCollection<DtoPosition> position = database.GetCollection<DtoPosition>("HistoricoPosicao");

            IMongoQueryable<DtoPosition> queryAbleHistoricoPosition = position.AsQueryable()
                .OrderByDescending(x => x.DateAtualizacao)
                .Where(x => x.DateEvent >= paramDataIni && x.DateEvent <= paramDataFim);

            List<DtoPosition> items = queryAbleHistoricoPosition.ToList();

            return items;
        }

        public List<DtoPosition> GetHistoricPosition(Int32 paramIdUnidadeRastreada, DateTime paramDataIni, DateTime paramDataFim)
        {
            IMongoDatabase database = MongoClient.GetDatabase("RadarFamily");
            IMongoCollection<DtoPosition> position = database.GetCollection<DtoPosition>("HistoricoPosicao");

            IMongoQueryable<DtoPosition> queryAbleHistoricoPosition = position.AsQueryable()
                .OrderBy(x => x.DateAtualizacao)
                .Where(x => x.IdUnidadeRastreada.Equals(paramIdUnidadeRastreada) && x.DateEvent >= paramDataIni && x.DateEvent <= paramDataFim);

            List<DtoPosition> items = queryAbleHistoricoPosition.ToList();

            return items;
        }

    }
}

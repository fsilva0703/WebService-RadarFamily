using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WS_RadarFamily.Models.Dto.Common
{
    public class ServiceResult<TEntidade>
    {
        public String MessageError { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Boolean IsValid { get { return String.IsNullOrEmpty(MessageError); } }

        [JsonIgnore]
        [XmlIgnore]
        public Int32 StatusCode { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public TEntidade Data { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Int32? ErrorCode { get; set; }

        public ServiceResult()
        {

        }

        public ServiceResult(String paramError)
        {
            MessageError = paramError;
        }
    }
}

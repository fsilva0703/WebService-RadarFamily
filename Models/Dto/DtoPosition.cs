﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_RadarFamily.Models.Dto
{
    public class DtoPosition
    {
        public Int64? _id { get; set; } //IdPosicao
        public Int32 IdUnidadeRastreada { get; set; }
        public String Name { get; set; }
        public DateTime DateEvent { get; set; }
        public DateTime? DateAtualizacao { get; set; }
        public String Address { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public Int32? IdRegra { get; set; }
        public String LatLong { get { return Latitude.ToString() + "|" + Longitude.ToString() + "|" + Name.ToString(); } }
        public String Avatar { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_RadarFamily.Models.Dto
{
    public class DtoResultLogin
    {
        public String Login { get; set; }
        public String Password { get; set; }
        public String Nome { get; set; }
        public Int32 IdUser { get; set; }
        public Int32 IdAdmin { get; set; }
        public Int32 IdUnidadeRastreada { get; set; }
        public Boolean IsAdmin { get; set; }
        public Int32 CalculoDistancia { get; set; }
        public Int32 IntervaloPosicao { get; set; }
        public String Avatar { get; set; }
    }
}

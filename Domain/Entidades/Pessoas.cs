using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Pessoas
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Renda { get; set; }
        public string Cota { get; set; }
        public string CID { get; set; }
        public int TotalParticipante { get; set; }
    }
}

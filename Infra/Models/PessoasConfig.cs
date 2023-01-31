#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datas.datas
{
  
    public partial class PessoasConfig
    {
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string CPF { get; set; }
        [Column("Data Nascimento", TypeName = "datetime")]
        public DateTime? Data_Nascimento { get; set; }
        [StringLength(255)]
        public string Renda { get; set; }
        [StringLength(255)]
        public string Cota { get; set; }
        [StringLength(255)]
        public string CID { get; set; }
    }
}
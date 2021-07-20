namespace Atacado.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Municipio")]
    public partial class Municipio
    {
        public int MunicipioID { get; set; }

        public int IBGE6 { get; set; }

        public int IBGE7 { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int MesoregiaoID { get; set; }

        public int MicroregiaoID { get; set; }

        public int UFID { get; set; }

        public int? Populacao { get; set; }

        public int? CEP { get; set; }

        [StringLength(2)]
        public string SiglaUF { get; set; }

        public virtual Mesoregiao Mesoregiao { get; set; }

        public virtual Microregiao Microregiao { get; set; }

        public virtual UnidadesFederacao Estado { get; set; }
    }
}

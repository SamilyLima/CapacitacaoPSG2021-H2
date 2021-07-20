namespace Atacado.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("produto")]
    public partial class produto
    {
        public int produtoid { get; set; }

        public int subcatid { get; set; }

        public int catid { get; set; }

        [Required]
        public string descricao { get; set; }

        public virtual subcategoria Subcategoria { get; set; }
    }
}

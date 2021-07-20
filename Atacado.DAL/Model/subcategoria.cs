namespace Atacado.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("subcategoria")]
    public partial class subcategoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subcategoria()
        {
            Produtos = new HashSet<produto>();
        }

        [Key]
        public int subcatid { get; set; }

        public int catid { get; set; }

        [Required]
        public string descricao { get; set; }

        public DateTime datainsert { get; set; }

        public virtual categoria categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<produto> Produtos { get; set; }
    }
}

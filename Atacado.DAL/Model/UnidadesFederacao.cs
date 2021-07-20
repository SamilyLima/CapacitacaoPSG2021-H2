namespace Atacado.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnidadesFederacao")]
    public partial class UnidadesFederacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadesFederacao()
        {
            Mesoregioes = new HashSet<Mesoregiao>();
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        public int UFID { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(2)]
        public string SiglaUF { get; set; }

        public int RegiaoID { get; set; }

        public DateTime? datainsert { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesoregiao> Mesoregioes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipios { get; set; }

        public virtual Regiao Regiao { get; set; }
    }
}

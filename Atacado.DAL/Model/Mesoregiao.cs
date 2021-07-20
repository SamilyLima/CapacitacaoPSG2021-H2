namespace Atacado.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesoregiao")]
    public partial class Mesoregiao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mesoregiao()
        {
            Microregioes = new HashSet<Microregiao>();
            Municipios = new HashSet<Municipio>();
        }

        public int MesoregiaoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int UFID { get; set; }

        public DateTime? datainsert { get; set; }

        public virtual UnidadesFederacao Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Microregiao> Microregioes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}

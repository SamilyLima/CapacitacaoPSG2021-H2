namespace Atacado.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Microregiao")]
    public partial class Microregiao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Microregiao()
        {
            Municipios = new HashSet<Municipio>();
        }

        public int MicroregiaoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int MesoregiaoID { get; set; }

        public DateTime? datainsert { get; set; }

        public virtual Mesoregiao Mesoregiao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}

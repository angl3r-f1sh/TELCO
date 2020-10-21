namespace TELCO.Models.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GENEROS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GENEROS()
        {
            VIDEOJUEGOS = new HashSet<VIDEOJUEGOS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Código")]
        public int cod_genero { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string txt_genero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIDEOJUEGOS> VIDEOJUEGOS { get; set; }
    }
}

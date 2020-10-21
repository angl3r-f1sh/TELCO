namespace TELCO.Models.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIDEOJUEGOS
    {
        [Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cod_videojuego { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(200)]
        public string txt_nombre { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Descripción")]
        public string txt_descripcion { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Fecha lanzamiento")]
        public DateTime fec_lanzamiento { get; set; }

        [Display(Name = "Plataforma")]
        public int cod_plataforma { get; set; }

        [Display(Name = "Género")]
        public int cod_genero { get; set; }

        public virtual GENEROS GENEROS { get; set; }

        public virtual PLATAFORMAS PLATAFORMAS { get; set; }
    }
}

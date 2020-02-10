using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebAppCRUD.Models.ViewModel
{
    public class TablaViewModel
    {

        public int Matricula { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public int Cedula { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        public int Edad { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Fecha_Nacimiento { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
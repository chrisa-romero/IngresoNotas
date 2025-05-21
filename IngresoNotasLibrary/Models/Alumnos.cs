using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngresoNotasLibrary.Models
{
    public class Alumno
    {
        [Key]
        [StringLength(7)]
        public string Carnet { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(150)]
        public string Apellidos { get; set; }

        [Required]
        public DateTime Fecha_Ingreso { get; set; }

        [Required]
        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }
    }

}

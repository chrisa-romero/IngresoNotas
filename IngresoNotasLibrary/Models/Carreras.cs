using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngresoNotasLibrary.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(150)]
        public string Facultad { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Materia> Materias { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngresoNotasLibrary.Models
{
    public class Materia
    {
        [Key]
        public int MateriaId { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
    }

}

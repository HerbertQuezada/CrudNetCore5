using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(50,ErrorMessage ="El {0} debe tener maximo de {1} y un minimo de {2}  caractes", MinimumLength = 5)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe tener maximo de {1} y un minimo de {2}  caractes", MinimumLength = 10)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "El Precio es obligatorio")]
        public float Precio { get; set; }
    }
}

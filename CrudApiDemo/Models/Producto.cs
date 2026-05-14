using System.ComponentModel.DataAnnotations;

namespace CrudApiDemo.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = default!;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 99999.99, ErrorMessage = "El precio debe estar entre 0.01 y 99999.99")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 10000, ErrorMessage = "El stock debe estar entre 0 y 10000")]
        public int Stock { get; set; }
    }
}

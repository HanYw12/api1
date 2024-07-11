using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Nombres { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Apellidos { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Identificacion { get; set; }
        [MaxLength(15)]
        public string? Telefono { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }
    }
}
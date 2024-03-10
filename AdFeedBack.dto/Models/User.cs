using System.ComponentModel.DataAnnotations;

namespace AdFeedBack.dto.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public string? ResetTokenPassword { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string? ConfirmToken { get; set; }
        public DateTime? ConfirmExpirationToken { get; set; }
        public DateTime? ConfirmAt { get; set; }
        // Relación con Perfil
        public Perfil Perfil { get; set; }

        // Relación con UserRole
        public ICollection<UserRole> UserRoles { get; set; }
    }
}

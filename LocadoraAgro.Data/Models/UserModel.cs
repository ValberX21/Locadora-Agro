namespace LocadoraAgro.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)] 
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public byte[] Password { get; set; } = Array.Empty<byte>();
    }
}

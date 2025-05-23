using System.ComponentModel.DataAnnotations;

namespace Q_A_Example.Models
{
    public class User
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        #endregion

        #region Relations

        public ICollection<Message> Messages { get; set; }

        #endregion
    }
}

using System.ComponentModel.DataAnnotations;

namespace Q_A_Example.Models
{
    public class Message
    {
        #region Properties

        public int Id { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا متن پیام خود را وارد کنید")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? ParentMessageId { get; set; }
        public List<Message> Replies { get; set; } = new();

        #endregion

        #region Relations

        public Message ParentMessage { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        #endregion
    }
}

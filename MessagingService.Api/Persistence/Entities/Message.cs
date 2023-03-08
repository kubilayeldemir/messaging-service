using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessagingService.Api.Persistence.Entities
{
    [Table("messages")]
    public class Message  : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("SenderUser")]
        public long SenderUserId { get; set; }
        [ForeignKey("ReceiverUser")]
        public long ReceiverUserId { get; set; }
        public string Content { get; set; }
        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }
}
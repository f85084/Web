using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web.Models
{
    [Table("Reply", Schema = "dbo")]
    public class Reply
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public string UserName { get; set; }
        public string Context { get; set; }
        public DateTime CreatDate { get; set; }
    }
}

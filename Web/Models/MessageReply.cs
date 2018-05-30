using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Message", Schema = "dbo")]
    public class MessageReply
    {
        public Message Message
        {
             get; 
             set;
        }

        public Reply Reply
        {
            get;
            set;
        }

    }
}

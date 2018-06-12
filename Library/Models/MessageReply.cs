using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library
{
    public class MessageReply
    {
        public Message Message
        {
            get;
            set;
        }

        public List<Reply> Replys
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class User
    {
        public int Id { get; set; }
        public string UserAccount { get; set; }
        public byte UserClass { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatDate { get; set; }
        public DateTime? MofiyDate { get; set; }
    }
}

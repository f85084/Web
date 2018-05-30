using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Library.User;

namespace Web.Models
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        public int Id { get; set; }
        public string UserAccount { get; set; }
        public byte UserClass { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime MofiyDate { get; set; }
    }
}


﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace RestAPI_ASPNET.Model
{
    [Table("users")]
    public class User
    {   
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }
        
        [Column("password")]
        public string PassWord { get; set; }
        
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
       
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
        
    }
}

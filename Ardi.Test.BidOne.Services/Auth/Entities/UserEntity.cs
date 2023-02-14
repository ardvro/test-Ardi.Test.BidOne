using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardi.Test.BidOne.Services.Auth.Entities
{
    internal class UserEntity
    {
        public string Username { get; set; } = "";

        public string Password { get; set; } = "";

        public string Email { get; set; } = "";

    }
}

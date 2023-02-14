using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardi.Test.BidOne.Interfaces.Auth.Domain
{
    public class User
    {
        [StringLength(85, MinimumLength = 4)]
        [Required]
        public string Username { get; set; } = "";

        [Required]
        [StringLength(255, MinimumLength = 6)]
        [RegularExpression(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$")]
        public string Email { get; set; } = "";

    }
}

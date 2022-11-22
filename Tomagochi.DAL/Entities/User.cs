using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomagochi.DAL.Entities
{
    public class User:IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string AvatarPath { get; set; }
    }
}

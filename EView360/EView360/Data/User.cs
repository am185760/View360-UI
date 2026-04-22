using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EView360.Data
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? UserLogin { get; set; }
        public string? Password { get; set; }
    }
}

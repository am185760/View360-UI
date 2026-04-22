using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string NewPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}

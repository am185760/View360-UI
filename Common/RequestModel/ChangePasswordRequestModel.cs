using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class ChangePasswordRequestModel
    {
        public long UserId { get; set; } 
        public string Password { get; set; }    
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Authentication_Demo1.Authentication
{
    public class LoginModel
    {
        [Required (ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required (ErrorMessage ="Password Required")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Security
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Contact
{
    public class ContactFormVm
    {
        [MaxLength(128)]
        [Required(ErrorMessage = "Nhập tên của bạn")]
        public string Name { set; get; }
        [MaxLength(128)]
        [EmailAddress(ErrorMessage = "Không phải email")]
        [Required(ErrorMessage = "Nhập email")]
        public string Email { set; get; }
        [MaxLength(128)]
        [Required(ErrorMessage = "Nhập tiêu đề")]
        public string Title { set; get; }
        [MaxLength(512)]
        [Required(ErrorMessage = "Nhập nội dung")]
        public string MessageBox { set; get; }
    }
}
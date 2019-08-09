using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="insert message")]
        [MaxLength(150,ErrorMessage ="Too Long")]
        public string Message { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}

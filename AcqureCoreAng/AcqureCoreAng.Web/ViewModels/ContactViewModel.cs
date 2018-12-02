using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcqureCoreAng.Web.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Too Long.")]
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PreProject.Models
{
    public class ContactModels
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
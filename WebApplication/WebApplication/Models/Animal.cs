using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebApplication.Models;

public class Animal
{
        public int IdAnimal { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [EmailAddress]
        public string Category { get; set; }
        [Required]
        public string Area { get; set; }
        
    
}
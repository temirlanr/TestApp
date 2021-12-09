using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_App.Models
{
    public class Item
    {
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string ArtistName { get; set; }
        
        [Required]
        public int Price { get; set; }
        
        [Required]
        public string Genre { get; set; }
    }
}

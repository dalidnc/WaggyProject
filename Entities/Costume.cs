﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WaggyProject.Entities
{
    public class Costume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int  Review { get; set; }
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }  

        [NotMapped]  
        public IFormFile ImageFile { get; set; }  
       

    }
}

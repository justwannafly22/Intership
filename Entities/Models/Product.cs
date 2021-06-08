﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Product
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("product_name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Max length for Name is 60 characters.")]
        public string Name { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price is required and it can`t be lower than 0.")]
        public double Price { get; set; }
        
        [Column("product_description")]
        [Required(ErrorMessage = "Product description is a required field.")]
        public string ContactNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<ReplacedPart> ReplacedParts { get; set; }
    }
}

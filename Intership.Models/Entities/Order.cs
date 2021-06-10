using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intership.Models.Entities
{
    public class Order
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("order_date")]
        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }

        [Column("count")]
        [Range(0, 150, ErrorMessage = "Count is required. It can`t be lower than 0 and bigger than 150.")]
        public int Count { get; set; }
        
        [Column("advanced_info")]
        [Required(ErrorMessage = "Advanced info is a required field.")]
        public string AdvancedInfo { get; set; }

        [ForeignKey(nameof(Client))]
        [Column("client_id")]
        [Required(ErrorMessage = "ClientId is a required field.")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey(nameof(Product))]
        [Column("product_id")]
        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}

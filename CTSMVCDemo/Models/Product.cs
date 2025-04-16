using System.ComponentModel.DataAnnotations.Schema;

namespace CTSMVCDemo.Models
{
    public class Product
    {
        public int proId { get; set; }
        public string proName { get; set; }
        public decimal price { get; set; }
        public int categoryId {  get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; }
    }
}

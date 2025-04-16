namespace CTSMVCDemo.Models
{
    public class Category
    {
        public int catId { get; set; }
        public string catName { get; set; }

        public IList<Product> Products { get; set; }
    }
}

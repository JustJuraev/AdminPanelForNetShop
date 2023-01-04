namespace AdminPanel.Models
{
    public class ProductProperty
    {
        public int Id { get; set; } 

        public int PropertyId { get; set; }

        public Property Property { get; set; }

        public int ProductId { get; set; }

        public string Value { get; set; }
    }
}

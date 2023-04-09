namespace LibrarySystem.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public int Rating { get; set; }
        public string Photo { get; set; }= string.Empty;
        public int AvailableNumer { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public int AuthorID { get; set; }
        public Author? Author { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
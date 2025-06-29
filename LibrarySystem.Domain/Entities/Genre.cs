namespace LibrarySystem.Domain.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

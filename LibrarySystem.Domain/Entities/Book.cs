namespace LibrarySystem.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        = DateTime.Now;

        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}

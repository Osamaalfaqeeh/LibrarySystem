namespace LibrarySystem.Application.DTOs.Genres
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int BookCount { get; set; }
    }
}

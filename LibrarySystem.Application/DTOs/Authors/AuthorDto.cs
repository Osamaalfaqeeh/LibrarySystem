namespace LibrarySystem.Application.DTOs.Authors
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public DateTime CreatedAt { get; set; }
        public int BookCount { get; set; }
    }
}

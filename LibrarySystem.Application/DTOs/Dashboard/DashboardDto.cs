namespace LibrarySystem.Application.DTOs.Dashboard
{
    public class DashboardDto
    {
        public int TotalBooks { get; set; }
        public int AvailableBooks { get; set; }
        public int BorrowedBooks { get; set; }
        public int TotalAuthors { get; set; }
        public int TotalMembers { get; set; }
        public int TotalGenres { get; set; }
    }
}

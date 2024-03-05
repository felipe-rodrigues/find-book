namespace find_book.ViewModel
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long TotalCopies { get; set; }
        public long CopiesInUse { get; set; }
        public string Type { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
    }
}

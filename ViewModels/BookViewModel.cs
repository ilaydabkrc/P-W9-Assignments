using Week9.Models;

namespace Week9.ViewModels
{
    public class BookViewModel
    {
       public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }
    }
}

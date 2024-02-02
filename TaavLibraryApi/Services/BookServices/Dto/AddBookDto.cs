namespace TaavLibraryApi.Services.BookServices.Dto
{
    public class AddBookDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }
    }
}

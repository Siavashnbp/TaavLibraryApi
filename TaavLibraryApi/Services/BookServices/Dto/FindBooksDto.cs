namespace TaavLibraryApi.Services.BookServices.Dto
{
    public class FindBooksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateOnly PublishDate { get; set; }
        public string Category { get; set; }
    }
}

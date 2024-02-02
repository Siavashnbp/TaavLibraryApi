namespace TaavLibraryApi.Services.BookServices.Dto
{
    public class UpdateBookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateOnly PublishDate { get; set; }
        public string Category { get; set; }
    }
}

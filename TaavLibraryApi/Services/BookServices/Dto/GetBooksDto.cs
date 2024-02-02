namespace TaavLibraryApi.Services.BookServices.Dto
{
    public class GetBooksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string Category { get; set; }
        public int RentCount { get; set; }
    }
}

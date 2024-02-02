namespace TaavLibraryApi.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PublishDate { get; set; }
        public int Count { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

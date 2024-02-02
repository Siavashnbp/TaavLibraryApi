namespace TaavLibraryApi.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateOnly PublishDate { get; set; }
        public string Author { get; set; }
    }
}

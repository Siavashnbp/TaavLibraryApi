namespace TaavLibraryApi.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserBook> Books { get; set; }
    }
}

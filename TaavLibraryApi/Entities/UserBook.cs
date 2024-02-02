namespace TaavLibraryApi.Entities
{
    public class UserBook
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public RentStatus RentStatus { get; set; }
        public DateTime RentTime { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
    public enum RentStatus
    {
        Rent,
        Returned
    }
}

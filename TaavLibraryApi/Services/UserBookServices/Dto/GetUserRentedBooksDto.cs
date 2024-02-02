using TaavLibraryApi.Entities;

namespace TaavLibraryApi.Services.UserBookServices.Dto
{
    public class GetUserRentedBooksDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public List<RentedBookDto>? Books { get; set; }
    }
    public class RentedBookDto
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime RentTime { get; set; }
        public RentStatus RentStatus { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}

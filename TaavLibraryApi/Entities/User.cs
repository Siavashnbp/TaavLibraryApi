﻿namespace TaavLibraryApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserBook> UserBooks { get; set; }
    }
}

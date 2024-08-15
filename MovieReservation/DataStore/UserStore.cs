using MovieReservation.Models;

namespace MovieReservation.DataStore
{
    internal static class UserStore
    {
        public static List<User> Users =
[
            new() {ID = 1, Name = "Syed", Email = "syed@02", Password = "Test@123", PhoneNumber = "9090909090"},
            new() {ID = 2, Name ="Gopi", Email = "gopi@02", Password= "Test@456", PhoneNumber = "8080808080"}

];

    }
}

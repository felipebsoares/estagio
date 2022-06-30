
using API.Models;

namespace API.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password) {
            var users = new List<User>{
                new() {Id = 1, Username = "felipe", Password = "felipe", Role = "employee"}
            };

            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
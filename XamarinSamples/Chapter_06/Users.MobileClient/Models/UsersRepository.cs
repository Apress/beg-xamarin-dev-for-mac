using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.MobileClient.Helpers;

namespace Users.MobileClient.Models
{
    public class UsersRepository
    {
        public List<User> Users { get; private set; }

        private static UsersRepository instance;

        public static async Task<UsersRepository> GetInstance()
        {
            // Create and initialize an instance only once
            if (instance == null)
            {
                instance = instance ?? new UsersRepository();

                instance.Users = (await UsersServiceHelper.Get()).ToList();
            }

            return instance;
        }

#pragma warning disable CS4014

	public void Delete(int userId)
    {
        if (UserExists(userId))
        {
            var userToDelete = GetById(userId);

            Users.Remove(userToDelete);

            UsersServiceHelper.Delete(userId);

        };
    }

    public void Update(User user)
    {
        if (UserExists(user.Id))
        {
            UsersServiceHelper.Update(user);
        };
    }

#pragma warning restore CS4014

		public User GetById(int userId)
        {
            return Users.Find(u => u.Id == userId);
        }

        private UsersRepository()
        {
			// Make default constructor private, 
			// so the class can be instantiated 
			// with the GetInstance method only
		}

        private bool UserExists(int userId)
        {
            return Users.Exists(u => u.Id == userId);
        }
    }
}
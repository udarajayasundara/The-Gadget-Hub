using TheGadgetHub.Models;

namespace TheGadgetHub.Data
{
    public class UserRepo
    {
        private AppDBContext dBContext;
        public UserRepo(AppDBContext appDBContext)
        {
            dBContext = appDBContext;
        }

        public bool Save()
        {
            int count = dBContext.SaveChanges();
            if (count>0)
            
                return true;
            return false;
            
        }

        public bool Create(User user)
        {
            if (user != null)
            {
                if (dBContext.Users.Any(u => u.Email == user.Email))
                    return false; // Or handle as needed
                dBContext.Users.Add(user);
                return Save();
            }
            return false;
        }

        public User? Authenticate(string email, string plainPassword)
        {
            var user = dBContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(plainPassword, user.HashedPassword);

            return isValid ? user : null;
        }

    }
}
using DistroTimer.Shared.DataBase;
using DistroTimer.Shared.Models;

namespace DistroTimer.Shared.Services;

[RegisterScoped]
public sealed class UsersService(DistroContext context)
{
    public void CreateUser(string name)
    {
        User user = new User
        {
            UserName = name,
            Distros = new List<DistroData>(),
            DateAdded = DateTime.Now
        };

        context.Add(user);
        context.SaveChanges();
    }

    public User? GetUser(string name)
        => context.Users.FirstOrDefault(u => u.UserName == name);

    public User? GetUser(int id)
        => context.Users.FirstOrDefault(u => u.UserId == id);

    /// <summary>
    /// Delete a user from the database registry.
    /// </summary>
    /// <returns>whether the user could be successfully removed.</returns>
    public bool RemoveUser(string name)
    {
        User? user = GetUser(name);
        if (user is null) return false;

        context.Remove(user);
        context.SaveChanges();

        return true;
    }
}
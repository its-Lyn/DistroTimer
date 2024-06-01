using DistroTimer.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DistroTimer.Shared.DataBase;

public class DistroContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<DistroData> Distros => Set<DistroData>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string dbDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".local",
            "share",
            "DistroTimer"
        );

        Directory.CreateDirectory(dbDir);

        string dbPath = Path.Combine(
            dbDir,
            "UserData.db"
        );
        options.UseSqlite($"Data Source={dbPath}");
    }
}
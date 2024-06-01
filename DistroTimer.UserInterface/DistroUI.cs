using DistroTimer.Shared.DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace DistroTimer.UserInterface;

public static class DistroUserInterface
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<DistroContext>();
        serviceCollection.AutoRegisterFromDistroTimerShared();
    }
}
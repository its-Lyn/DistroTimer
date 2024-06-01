using DistroTimer.Shared.DataBase;
using Microsoft.Extensions.DependencyInjection;

namespace DistroTimer.CommandLine;

public static class DistroCommandLine
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<DistroContext>();
        serviceCollection.AutoRegisterFromDistroTimerCommandLine();
        serviceCollection.AutoRegisterFromDistroTimerShared();

        ServiceProvider services = serviceCollection.BuildServiceProvider();
        services.GetRequiredService<DistroParser>().Parse(args);

    }
}

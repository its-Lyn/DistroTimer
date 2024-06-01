using CommandLine;
using DistroTimer.CommandLine.Colour;
using DistroTimer.CommandLine.Verbs;
using DistroTimer.Shared.DataBase;
using DistroTimer.Shared.Models;
using DistroTimer.Shared.Services;

namespace DistroTimer.CommandLine;

[RegisterSingleton]
public class DistroParser(UsersService users, DistroContext db)
{
    private readonly ColourManager _colour = new ColourManager();

    public void Parse(string[] args)
    {
        Parser.Default.ParseArguments<UserOptions>(args)
            .WithParsed<UserOptions>(user =>
            {
                if (user.ListFlag)
                {
                    if (!db.Users.Any())
                    {
                        Console.WriteLine("There are currently no users registered in the database.");
                        return;
                    }

                    foreach (User usr in db.Users)
                    {
                        Console.WriteLine($"{_colour.ColourText(usr.UserName, new TrueColour(237, 172, 250))} {_colour.ColourText($"(#{usr.UserId})", new TrueColour(133, 131, 131))}");
                        Console.WriteLine($"Added on {usr.DateAdded:dd/MM/yyyy} at {usr.DateAdded:HH:mm}");
                        Console.WriteLine();
                    }

                    return;
                }

                if (user.UserName is null || string.IsNullOrEmpty(user.UserName.Trim()))
                {
                    Console.WriteLine(_colour.GetErrorFrom("You must specify a user!"));
                    return;
                }

                if (user.AddFlag)
                {
                    if (user.RemoveFlag)
                    {
                        Console.WriteLine(_colour.GetErrorFrom("You can't have both add and remove..."));
                        return;
                    }
                    
                    users.CreateUser(user.UserName);
                    Console.WriteLine(
                        _colour.ColourText($"Created user {user.UserName} successfully.", AsciiColour.Green)
                    );
                    
                    return;
                }

                if (!user.RemoveFlag) return;
                if (user.AddFlag) 
                { 
                    Console.WriteLine(_colour.GetErrorFrom("You can't have both add and remove...")); 
                    return;
                }

                bool success = users.RemoveUser(user.UserName);
                if (!success)
                {
                    Console.WriteLine(
                        _colour.GetErrorFrom($"Could not find user {user.UserName}. Maybe check your spelling?")
                    );

                    return;
                }

                Console.WriteLine(
                    _colour.ColourText($"Successfully deleted user {user.UserName}.", AsciiColour.Green)
                );
            });
    }
}
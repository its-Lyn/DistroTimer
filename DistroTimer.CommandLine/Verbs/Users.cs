using CommandLine;

namespace DistroTimer.CommandLine.Verbs;

[Verb("user", HelpText = "Manage your users.")]
public class UserOptions
{
    [Option('a', "add", Required = false, HelpText = "Add a user to the database.")] 
    public bool AddFlag { get; set; }

    [Option('r', "remove", Required = false, HelpText = "Remove a user from the database.")]
    public bool RemoveFlag { get; set; }

    [Option('n', "name", Required = false, HelpText = "The name of the user.")]
    public string? UserName { get; set; }

    [Option('l', "list", Required = false, HelpText = "List every user registered in the database.")]
    public bool ListFlag { get; set; }
}
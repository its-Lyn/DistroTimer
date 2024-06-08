using CommandLine;

namespace DistroTimer.CommandLine.Verbs;

public class DistroOptions
{
    [Option('a', "add", Required = false, HelpText = "Add a distro to the database.")] 
    public bool AddFlag { get; set; }
    
    [Option('r', "remove", Required = false, HelpText = "Remove a distro to the database.")] 
    public bool RemoveFlag { get; set; }
    
    [Option('n', "distro-name", Required = false, HelpText = "The name of the distro.")] 
    public string? DistroName { get; set; }
    
    [Option('d', "date", Required = false, HelpText = "The date the distro was installed (dd/mm/yyyy)")] 
    public string? Date { get; set; }
    
    [Option('u', "user", Required = false, HelpText = "The user's name.")] 
    public string? UserName { get; set; }
    
    [Option('l', "list-all", Required = false, HelpText = "Show all distros registered in the database.")] 
    public bool ListFlag { get; set; }
    
    [Option('s', "show", Required = false, HelpText = "Show a distro.")] 
    public string? ShowName { get; set; }

    [Option('k', "keep-going", Required = false, HelpText = "Keep listing distro times.")]
    public bool KeepGoing { get; set; }
}
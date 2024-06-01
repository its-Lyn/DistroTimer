using System.Text;

namespace DistroTimer.CommandLine.Colour;

public class ColourManager
{
   public ColourManager()
   {
      Stream? stdout = Console.OpenStandardOutput();
      StreamWriter? writer = new StreamWriter(stdout, Encoding.ASCII)
      {
         AutoFlush = true
      };

      Console.SetOut(writer);
   }
   
   public string ColourText(string text, AsciiColour asciiColour)
      => $"\x1b[1;{(byte)asciiColour}m{text}\x1b[0m";

   public string ColourText(string text, TrueColour colour)
      => $"\x1b[38;2;{colour.R};{colour.B};{colour.G}m{text}\x1b[0m";

   public string GetErrorFrom(string text)
      => $"\x1b[1;31mERROR:\x1b[0m {text}";
}
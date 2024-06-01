namespace DistroTimer.CommandLine.Colour;

public enum AsciiColour
{ 
    Green = 32,
    Red = 31,
    Yellow = 93,
    Magenta = 95,
    Cyan = 96
}

public record struct TrueColour(byte R, byte G, byte B);
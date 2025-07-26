namespace TF;

internal class Program
{
    private static void Main(string[] args) => Console.WriteLine(new TextManager(new Parser(args)).OutputText());
}
namespace TF;

public class Parser
{
    private string[] _args;

    public Parser(string[] args) => _args = args;

    public FlagsWithValues InputFlagsWithValues
    {
        get
        {
            FlagsWithValues result = new FlagsWithValues();

            foreach (var arg in _args)
                if (arg.StartsWith("-"))
                {
                    var parts = arg.Substring(1).Split('+', 2);
                    result.AddFlag(parts[0]);
                    result.AddVal(parts.Length > 1 ? parts[1] : null);
                }

            return result;
        }
    }

    public string? InputText => _args.Length > 0 ? _args[0] : null;
}

public struct FlagsWithValues()
{
    public List<string> Flags { get; private set; } = new List<string>();
    public List<string?> Val { get; private set; } = new List<string?>();

    public void AddFlag(string i) => Flags.Add(i);

    public void AddVal(string? i) => Val.Add(i);
}
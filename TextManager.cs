namespace TF;

public class TextManager
{
    public struct Flag
    {
        public Flag(string name, string inputArgs, string description)
        {
            Name = name;
            InputArgs = inputArgs;
            Description = description;
        }
        public string Name { get; private set; }
        public string InputArgs { get; private set; }
        public string Description { get; private set; }
    }

    public struct FlagsContainer()
    {
        public List<Flag> Flags { get; private set; } = new List<Flag>()
        {
            new Flag("l",
            "number of a specific character in a word",
            "makes letters lowercase"),

            new Flag("h",
            "number of a specific character in a word",
            "makes letters capital"),

            new Flag("wc",
            "",
            "print words count"),
            new Flag("cc",
            "",
            "print chars count"),
        };

        public bool ContaintByName(string name)
        {
            for (int i = 0; i < Flags.Count; i++) if (Flags[i].Name == name) return true;
            return false;
        }
    }

    private FlagsContainer _providedFlags = new FlagsContainer();

    private Parser _parser;

    public TextManager(Parser parser) => _parser = parser;

    public string? OutputText()
    {
        string result = _parser.InputText != null ? _parser.InputText : null!;

        if (result == null)
        {
            Console.WriteLine($"Input text is null");
            WriteHelpMenu();
            Environment.Exit(1);
        }

        for (int i = 0; i < _parser.InputFlagsWithValues.Flags.Count; i++)
            TransformTextByFlag(ref result, _parser.InputFlagsWithValues.Flags[i], _parser.InputFlagsWithValues.Val[i]);

        return result;
    }

    private void WriteHelpMenu()
    {
        Console.WriteLine("\nHelp list:\n\n");
        foreach (var flag in _providedFlags.Flags)
            Console.WriteLine($"| -{flag.Name}+<{flag.InputArgs}>\t\t |   {flag.Description}");

        Console.WriteLine("\nExample: \"SAMPLE TEXT\" -l -h+0");
        Console.WriteLine("Output: Sample Text");
    }

    private void TransformTextByFlag(ref string text, string flag, string? value)
    {
        if (!_providedFlags.ContaintByName(flag))
        {
            Console.WriteLine($"Invalid flag {flag}");
            return;
        }


        if (flag == "l")
        {
            if (value == null)
                text = text.ToLower();
            else
            {
                var words = text.Split(new char[] { ' ' }, StringSplitOptions.None);

                for (int i = 0; i < words.Length; i++)
                    for (int k = 0; k < words[i].Length; k++)
                        if (k == int.Parse(value)) words[i] = words[i].Remove(k, 1).Insert(k, words[i][k].ToString().ToLower());
                text = string.Join(" ", words);
            }
        }

        if (flag == "h")
        {
            if (value == null) text = text.ToUpper();
            else
            {
                var words = text.Split(new char[] { ' ' }, StringSplitOptions.None);

                for (int i = 0; i < words.Length; i++)
                    for (int k = 0; k < words[i].Length; k++)
                        if (k == int.Parse(value)) words[i] = words[i].Remove(k, 1).Insert(k, words[i][k].ToString().ToUpper());
                text = string.Join(" ", words);
            }
        }

        if (flag == "wc")
            Console.WriteLine($"words count: {text.Split(new char[] { ' ' }).Length}");

        if (flag == "cc")
            Console.WriteLine($"chars count: {text.Length}");

    }
}
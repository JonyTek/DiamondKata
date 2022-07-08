namespace Dojo.Diamond.Features;

public class DiamondBuilder
{
    private static readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static IReadOnlyList<string> Build(char character)
    {
        if (!char.IsLetter(character))
        {
            throw new ArgumentException($"Input '{character}' must be letter");
        }

        var inputIndex = Array.IndexOf(Alphabet, char.ToUpper(character));
        
        var totalLines = inputIndex * 2 + 1;
        var diamondLines = new string[totalLines];

        foreach (var i in Enumerable.Range(0, inputIndex + 1))
        {
            var secondHalfOfTheLine = Enumerable
                .Range(0, inputIndex + 1)
                .Select(index => index == i ? Alphabet[i] : ' ')
                .ToArray();
            var firstHalfOfTheLine = secondHalfOfTheLine.Reverse();
            
            var fullLine = firstHalfOfTheLine.Concat(secondHalfOfTheLine.Skip(1)).ToArray();
            var fullLineAsString = new string(fullLine);

            diamondLines[i] = fullLineAsString;
            diamondLines[totalLines - 1 - i] = fullLineAsString;
        }

        return diamondLines;
    }
}

namespace Task_3;

public static class Program
{
    private static void RemoveLongestWordsFromText(string inputFilePath, string outputFilePath)
    {
        var text = File.ReadAllText(inputFilePath);

        var words = text.Split(' ', ',');
        var longestLength = words.OrderByDescending(word => word.Length).First().Length;
        var longestWords = words.Where(word => word.Length == longestLength);
        longestWords = longestWords.Distinct().ToList();

        foreach (var word in longestWords)
        {
            text = text.Replace(word, "");
        }
        
        if (File.Exists(outputFilePath))
            File.Delete(outputFilePath);
    
        Console.WriteLine("Longest words: ");
        foreach (var word in longestWords)
        {
            Console.Write($"{word} ");
        }

        using var streamWriter = File.CreateText(outputFilePath);
        {
            streamWriter.WriteLine(text);
        }
    }
    
    public static void Main()
    {
        var inputFilePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_3/Resources/input.txt";
        var outputFilePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_3/Resources/output.txt";


        RemoveLongestWordsFromText(inputFilePath, outputFilePath);
    }
}
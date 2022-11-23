namespace Task_2;

public static class Program
{
    private static void FindWordOfLengthFromText(string inputFilePath, string outputFilePath, int length)
    {
        var text = File.ReadAllText(inputFilePath);

        var words = text.Split(' ', '.', ',', ';', ':', '!', '?');

        var wordsOfLength = new List<string>();

        foreach (var word in words)
            if (word.Length == length)
                wordsOfLength.Add(word);

        wordsOfLength = wordsOfLength.Distinct().ToList();
        
        if (wordsOfLength.Count == 0)
            Console.WriteLine($"There are no words with the length of {length}");
        else
        {
            Console.WriteLine($"Words of length of {length}:");
            
            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);
        
            using var streamWriter = File.CreateText(outputFilePath);
            {
                foreach (var word in wordsOfLength)
                {
                    streamWriter.WriteLine(word);
                    Console.WriteLine(word);
                }
            }
        }
    }
    
    public static void Main()
    {
        var inputFilePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_1/Resources/input.txt";
        var outputFilePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_1/Resources/output.txt";

        FindWordOfLengthFromText(inputFilePath, outputFilePath, 5);
    }
}
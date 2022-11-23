using System.Text.RegularExpressions;

namespace Task_1;

public static class Program
{
    public static void Main()
    {
        var inputText = File.ReadAllText(@"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_1/Resources/input.txt");
        Regex regex = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        MatchCollection matchCollection = regex.Matches(inputText);

        if (matchCollection.Count == 0)
            Console.WriteLine("There are no matches");
        else
        {
            var outputFilePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_1/Resources/output.txt";
        
            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);

            using var streamWriter = File.CreateText(outputFilePath);
            {
                foreach (Match match in matchCollection)
                {
                    streamWriter.WriteLine(match.ToString());
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
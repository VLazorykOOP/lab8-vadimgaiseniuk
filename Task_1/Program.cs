using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Task_1;

public static class Program
{
    private static List<Match> FindIpAddresses(string inputText)
    {
        Regex regex = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        var matchCollection = regex.Matches(inputText).ToList();

        if (matchCollection.Count == 0)
            Console.WriteLine("There are no matches");
        
        var outputFilePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_1/Resources/output.txt";
    
        if (File.Exists(outputFilePath))
            File.Delete(outputFilePath);

        Console.WriteLine($"The amount of IP-addresses: {matchCollection.Count}");
        
        using var streamWriter = File.CreateText(outputFilePath);
        {
            foreach (Match match in matchCollection)
            {
                streamWriter.WriteLine(match.ToString());
                Console.WriteLine(match.Value);
            }
        }

        return matchCollection;
    }
    
    public static void Main()
    {
        var inputText = File.ReadAllText(@"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_1/Resources/input.txt");

        var matchCollection = FindIpAddresses(inputText);
        
        Console.WriteLine("Delete IP-address - 1");
        Console.WriteLine("Change IP-address - 2");
        var choice = Convert.ToInt32(Console.ReadLine());

        var index = 0;
        
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the index: ");
                index = Convert.ToInt32(Console.ReadLine());

                inputText = inputText.Replace(matchCollection[index].ToString(), "");
                FindIpAddresses(inputText);
                break;
            
            case 2:
                Console.WriteLine("Enter the index: ");
                index = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Enter the new IP-address: ");
                var newValue = Convert.ToString(Console.ReadLine());

                inputText = inputText.Replace(matchCollection[index].ToString(), newValue);
                FindIpAddresses(inputText);
                break;
        }
    }
}
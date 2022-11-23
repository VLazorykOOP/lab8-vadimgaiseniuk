namespace Task_5;

public static class Program
{
    private static void ShowFileInfo(FileInfo file)
    {
        Console.WriteLine($"Info about file {file.Name}");
        file.GetType().GetProperties().ToList().ForEach(property => Console.WriteLine($"{property.Name} = {property.GetValue(file)}"));
        Console.WriteLine();
    }

    public static void Main()
    {
        DirectoryInfo tempDirectory = new DirectoryInfo(@"/run/media/vadimir/New Volume/tmp");
        if (tempDirectory.Exists)
        {
            tempDirectory.Delete(true);
        }
        tempDirectory.Create();
        
        var firstDirectory = tempDirectory.CreateSubdirectory("Gaiseniuk_Vadim1");
        var secondDirectory = tempDirectory.CreateSubdirectory("Gaiseniuk_Vadim2");

        FileInfo firstFile = new FileInfo(Path.Combine(firstDirectory.FullName, "t1.txt"));
        FileInfo secondFile = new FileInfo(Path.Combine(firstDirectory.FullName, "t2.txt"));

        using var firstStreamWriter = firstFile.CreateText();
        {
            firstStreamWriter.WriteLine("<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
        }
        using var secondStreamWriter = secondFile.CreateText();
        {
            secondStreamWriter.WriteLine("<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>");
        }

        FileInfo thirdFile = new FileInfo(Path.Combine(secondDirectory.FullName, "t3.txt"));

        using var streamWriter = thirdFile.CreateText();
        {
            using (StreamReader firstStreamReader = firstFile.OpenText(), secondStreamReader = secondFile.OpenText())
            {
                var line = firstStreamReader.ReadLine();
                streamWriter.WriteLine(line);
                line = secondStreamReader.ReadLine();
                streamWriter.WriteLine(line);
        
            }
        }

        ShowFileInfo(firstFile);
        ShowFileInfo(secondFile);
        ShowFileInfo(thirdFile);


        secondFile.MoveTo(Path.Combine(secondDirectory.FullName, "t2.txt"));
        firstFile.MoveTo(Path.Combine(secondDirectory.FullName, "t1.txt"));

        secondDirectory.MoveTo(Path.Combine(tempDirectory.FullName,"All"));
        firstDirectory.Delete(true);

        Console.WriteLine("\nInfo about directory All:");
        secondDirectory.GetFiles().ToList().ForEach(file => ShowFileInfo(file));
    }
}
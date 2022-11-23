using System.Text;

namespace Task_4;

public static class Program
{
    public static void Main()
    {
        var filePath = @"/home/vadimir/RiderProjects/lab8-vadimgaiseniuk/Task_4/Resources/binaryFile.dat";
        var n = 0;

        do
        {
            Console.WriteLine("Enter n: ");
            n = Convert.ToInt32(Console.ReadLine());
        } while (n < 0);
        
        if (File.Exists(filePath))
            File.Delete(filePath);

        using var stream = File.Create(filePath);
        {
            using var binaryWriter = new BinaryWriter(stream, Encoding.Default, false);
            {
                for (int i = 1; i < n; i++)
                    binaryWriter.Write(1.0 / i);
            }

            using var binaryReader = new BinaryReader(stream, Encoding.Default, false);
            {
                for (int i = 16; i < stream.Length; i += 24)
                {
                    stream.Seek(i, SeekOrigin.Begin);
                    Console.WriteLine($"{binaryReader.ReadDouble()}");
                }
            }
        }
    }
}
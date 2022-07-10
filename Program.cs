using VideoHelper;
using VideoHelper.Adapter;

public class Program
{
    public static void Main(string[] args){
        Console.WriteLine("~~~~~~~~~~~ Video Helper ~~~~~~~~~~~");

        var config = ArgumentParser.Parse(args);

        var converter = new ConverterService(new FfmpegAdapter());

        converter.Process(config);
    }   
}
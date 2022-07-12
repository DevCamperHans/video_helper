using VideoHelper;
using VideoHelper.Adapter;

public class Program
{
    public static void Main(string[] args){
        Console.WriteLine("~~~~~~~~~~~ Video Helper ~~~~~~~~~~~");


        var converter = new ConverterService(new FfmpegAdapter());
        var configurationService = new ConfigurationService();

        var config = ArgumentParser.Parse(args, configurationService);

        if(config.CreateConfig){
            configurationService.StoreConfig(config);
        }

        Task.WaitAll(converter.Process(config.VideoConfig));
    }   
}
namespace VideoHelper;

using VideoHelper.Adapter;

public class ConverterService{

    private readonly IVideoConverterAdapter _adapter;

    public ConverterService(IVideoConverterAdapter adapter){
        _adapter = adapter;
    }

    public async Task Process(VideoConfig config){

        var start = DateTime.Now;
        Console.WriteLine("Start processing...");
        foreach(var file in config.Files)
        {
            var fileName = Path.GetFileName(file);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
            var fileExtension = Path.GetExtension(file);
            var path = Path.GetFullPath(file).Replace(fileName, "");

            if(config.Marker != null){
                fileNameWithoutExtension = fileNameWithoutExtension.Replace(config.Marker, "");
            }

            await _adapter.Process(path, fileName, fileNameWithoutExtension + "_processed" + fileExtension, config);
        }
        var end = DateTime.Now;

        
        Console.WriteLine($"Finished. Processing tokes {(end - start).TotalSeconds}s");
    }
}
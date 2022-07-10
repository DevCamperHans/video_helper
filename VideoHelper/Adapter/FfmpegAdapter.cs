namespace VideoHelper.Adapter;

public class FfmpegAdapter : IVideoConverterAdapter{
    private const string FfmpegExeName =  "ffmpeg.exe";

    public void Rotate(string path, string fileName, string outoutFileName){

        Console.WriteLine($"Rotating now {fileName}");

        var input = Path.Join(path, fileName);
        var output = Path.Join(path, outoutFileName);

        var cmd = $"{FfmpegExeName} -i {input} -vf \"vflip,hflip\" {output}";

        Console.WriteLine($"{cmd}");
    }

}
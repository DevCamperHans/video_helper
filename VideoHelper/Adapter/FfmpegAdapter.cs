using System.Diagnostics;

namespace VideoHelper.Adapter;

public class FfmpegAdapter : IVideoConverterAdapter{
    private const string FfmpegExeName =  "ffmpeg.exe";

    public void Rotate(string path, string fileName, string outFileName){

        Console.WriteLine($"Rotating now {fileName}");

        var input = Path.Join(path, fileName);
        var output = Path.Join(path, outFileName);

        var ffmpegArgs = $"-i {input} -vf \"vflip,hflip\" {output}";

        Process(FfmpegExeName, ffmpegArgs);
    }

    private void Process(string exe, string ffmpegArgs){


        Console.WriteLine($"{exe} {ffmpegArgs}");

        var p = new Process
            {
                StartInfo =
                {
                    FileName = FfmpegExeName,          
                    Arguments = ffmpegArgs
                }
            }.Start();
    }

}
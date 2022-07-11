using System.Diagnostics;

namespace VideoHelper.Adapter;

public class FfmpegAdapter : IVideoConverterAdapter{
    private const string FfmpegExeName =  "ffmpeg.exe";

    public void Process(string path, string fileName, string outFileName, VideoConfig config){

        var input = Path.Join(path, fileName);
        var output = Path.Join(path, outFileName);

        var ffmpegArgs = $"-i {input} -vf \"{Scale(config)}, {Rotate(config)}\" {output}"; 
        Process(FfmpegExeName, ffmpegArgs);
    }

    private string? Rotate(VideoConfig config)
    {
        if(config.RotationInDegree == null){
            return null;
        }

        return "vflip,hflip";
    }


    private string? Scale(VideoConfig config)
    {
        if(config.ScaleOptions == null){
            return null;
        }

        return $"scale={config.ScaleOptions.Width}:{config.ScaleOptions.Hight}";
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
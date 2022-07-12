namespace VideoHelper;

using System.Linq;

public static class ArgumentParser{
    public static Configuration Parse(string[] arguments, ConfigurationService configurationService){

        var indexConfig = arguments.ToList().IndexOf("--config");
        var indexStore = arguments.ToList().IndexOf("-s");
        var indexFiles = arguments.ToList().IndexOf("-f");
        var files = new List<string>();

        var indexRotation = arguments.ToList().IndexOf("-r");
        string? rotation = null;

        var indexMarker = arguments.ToList().IndexOf("-m");
        string? marker = null;
        var indexAll = arguments.ToList().IndexOf("-A");
        var indexDirectory = arguments.ToList().IndexOf("-d");
        
        VideoScaleOptions? scaleOptions = null;
        var indexWidth = arguments.ToList().IndexOf("-w");
        var indexHight = arguments.ToList().IndexOf("-h");

        
            
        string workingDir = Path.GetFullPath(".");


        if(IsArgumentOfGivenIndexValid(arguments, indexConfig)){
            var pathToConfig = arguments[indexConfig + 1];
            
            if(File.Exists(pathToConfig))
            {
                var videoConfig = configurationService.RestoreConfig(pathToConfig);

                return new Configuration(false, null, videoConfig);
            }
        }

        if(IsArgumentOfGivenIndexValid(arguments, indexFiles))
        {
            for(int i = indexFiles + 1; i < arguments.Length && !arguments[i].StartsWith("-"); i++){
                var file = arguments[i];

                if(Path.IsPathFullyQualified(file)){
                    files.Add(arguments[i]);
                } else {
                    var fullPathFile = Path.GetFullPath(file);
                    files.Add(fullPathFile);
                }
            }
        }


        if(IsArgumentOfGivenIndexValid(arguments, indexRotation))
        {
            rotation = arguments[indexRotation + 1];
        }

        if(IsArgumentOfGivenIndexValid(arguments, indexWidth) && IsArgumentOfGivenIndexValid(arguments, indexHight))
        {
            var width = arguments[indexWidth + 1];
            var hight = arguments[indexHight + 1];

            scaleOptions = new VideoScaleOptions(width, hight);
        }


        if(IsArgumentOfGivenIndexValid(arguments, indexMarker))
        {
            marker = arguments[indexMarker + 1];

            if(indexDirectory >= 0 && IsArgumentOfGivenIndexValid(arguments, indexDirectory))
            {                
                workingDir = Path.GetFullPath(arguments[indexDirectory + 1]);                
            }

            var videoFiles = Directory.GetFiles(workingDir)
                    .Where(file => Path.GetExtension(file).ToLower() == ".mp4")
                    .Where(file => file.Contains(marker));

            files.AddRange(videoFiles);        
        }

        if(indexAll >= 0)
        {   

            if(indexDirectory >= 0 && IsArgumentOfGivenIndexValid(arguments, indexDirectory))
            {                
                workingDir = Path.GetFullPath(arguments[indexDirectory + 1]);                
            }

            var videoFiles = Directory.GetFiles(workingDir)
                    .Where(file => Path.GetExtension(file).ToLower() == ".mp4");

            files.AddRange(videoFiles);        
        }

        var filesToProcess = files
            .Where(file => File.Exists(file))
            .Distinct()
            .ToArray();

        filesToProcess.ToList().ForEach(it => Console.WriteLine(it));    

        return new Configuration(indexStore >= 0, indexStore >= 0 ? Path.Join(workingDir, "vh_config.conf") : null, new VideoConfig(filesToProcess, rotation, marker, scaleOptions));
    }


    private static bool IsArgumentOfGivenIndexValid(string[] args, int index){
    
        if(args == null){
            return false;
        }

        if(index < 0 || index + 1 >= args.Length){
            return false;
        }

        if(args[index + 1].StartsWith("-") ){
            return false;
        }

        return true;
    }
}
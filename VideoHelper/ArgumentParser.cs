namespace VideoHelper;

using System.Linq;

public static class ArgumentParser{
    public static VideoConfig Parse(string[] arguments){

        var indexRotation = arguments.ToList().IndexOf("-r");
        string? rotation = null;
        
        if(IsArgumentOfGivenIndexValid(arguments, indexRotation))
        {
            rotation = arguments[indexRotation + 1];
        }

        var config = new VideoConfig(rotation);

        Console.WriteLine($"Config: {config}");


        return config;
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
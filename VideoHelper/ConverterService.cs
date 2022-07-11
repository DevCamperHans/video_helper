namespace VideoHelper;

using VideoHelper.Adapter;

public class ConverterService{

    private readonly IVideoConverterAdapter _adapter;

    public ConverterService(IVideoConverterAdapter adapter){
        _adapter = adapter;
    }

    public void Process(VideoConfig config){
        foreach(var file in config.Files)
        {
            var fileName = Path.GetFileName(file);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
            var fileExtension = Path.GetExtension(file);
            var path = Path.GetFullPath(file).Replace(fileName, "");

            if(config.RotationInDegree != null){
                _adapter.Rotate(path, fileName, fileNameWithoutExtension + "_rotated" + fileExtension);
            }
        }
    }
}
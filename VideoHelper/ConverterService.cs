namespace VideoHelper;

using VideoHelper.Adapter;

public class ConverterService{

    private readonly IVideoConverterAdapter _adapter;

    public ConverterService(IVideoConverterAdapter adapter){
        _adapter = adapter;
    }

    public void Process(VideoConfig config){

        if(config.Rotate != null){
            _adapter.Rotate("path", "input", "output");
        }
    }
}
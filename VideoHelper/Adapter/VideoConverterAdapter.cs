namespace VideoHelper.Adapter;

public interface IVideoConverterAdapter
{
    public void Process(string path, string fileName, string outFileName, VideoConfig config);
}

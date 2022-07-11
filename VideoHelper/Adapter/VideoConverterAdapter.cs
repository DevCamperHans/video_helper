namespace VideoHelper.Adapter;

public interface IVideoConverterAdapter
{
    public Task Process(string path, string fileName, string outFileName, VideoConfig config);
}

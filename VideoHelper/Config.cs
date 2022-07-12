namespace VideoHelper;

public record Configuration(
    bool CreateConfig, 
    string? PathToStoreConfig, 
    VideoConfig VideoConfig);
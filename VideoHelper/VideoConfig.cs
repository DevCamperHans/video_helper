namespace VideoHelper;

public record VideoConfig(
    string[] Files, 
    string? RotationInDegree = null,
    VideoScaleOptions? ScaleOptions = null);


public record VideoScaleOptions(
    string Width,
    string Hight);
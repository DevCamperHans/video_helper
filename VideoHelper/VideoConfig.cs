namespace VideoHelper;

public record VideoConfig(
    string[] Files, 
    string? RotationInDegree = null,
    string? Marker = null,
    VideoScaleOptions? ScaleOptions = null);


public record VideoScaleOptions(
    string Width,
    string Hight);
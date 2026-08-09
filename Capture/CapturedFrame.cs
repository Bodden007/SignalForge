namespace SignalForge.Capture;

public sealed record CapturedFrame(
    DateTimeOffset Timestamp,
    ReadOnlyMemory<byte> Data);

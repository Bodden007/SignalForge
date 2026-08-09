namespace SignalForge.Runtime;

public sealed record TelemetrySnapshot
{
    public static TelemetrySnapshot Empty { get; } = new();

    public DateTimeOffset Timestamp { get; init; }
    public float Pressure { get; init; }
    public float Temperature { get; init; }
    public float Density { get; init; }
    public float FlowRate { get; init; }
}

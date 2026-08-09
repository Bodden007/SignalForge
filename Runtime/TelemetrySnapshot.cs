namespace SignalForge.Runtime;

/// <summary>
/// Normalized snapshot of the process values decoded from the source protocol.
/// The rest of SignalForge works only with this model and does not depend on
/// packet offsets, byte order or other details of the source protocol.
/// </summary>
public sealed record TelemetrySnapshot
{
    public static TelemetrySnapshot Empty { get; } = new();

    /// <summary>Time when the source packet was captured.</summary>
    public DateTimeOffset Timestamp { get; init; }

    /// <summary>First pressure value.</summary>
    public float Pressure1 { get; init; }

    /// <summary>Second pressure value.</summary>
    public float Pressure2 { get; init; }

    /// <summary>Total instantaneous pumping rate.</summary>
    public float TotalRate { get; init; }

    /// <summary>Volume pumped during the current stage.</summary>
    public float StageVolume { get; init; }

    /// <summary>Total volume pumped during the current job.</summary>
    public float JobVolume { get; init; }

    /// <summary>Fluid density at the outlet.</summary>
    public float DensityOut { get; init; }
}

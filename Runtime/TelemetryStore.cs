namespace SignalForge.Runtime;

public sealed class TelemetryStore
{
    private TelemetrySnapshot _current = TelemetrySnapshot.Empty;

    public TelemetrySnapshot Current => Volatile.Read(ref _current);

    public void Update(TelemetrySnapshot snapshot)
    {
        ArgumentNullException.ThrowIfNull(snapshot);
        Volatile.Write(ref _current, snapshot);
    }
}

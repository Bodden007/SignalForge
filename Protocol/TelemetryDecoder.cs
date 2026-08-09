using SignalForge.Runtime;

namespace SignalForge.Protocol;

public sealed class TelemetryDecoder
{
    public bool TryDecode(LlcPacket packet, out TelemetrySnapshot snapshot)
    {
        // TODO: Reverse-engineered field decoding will be added here.
        snapshot = TelemetrySnapshot.Empty with { Timestamp = packet.Timestamp };
        return false;
    }
}

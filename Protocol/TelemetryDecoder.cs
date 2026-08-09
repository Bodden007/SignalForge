using SignalForge.Runtime;

namespace SignalForge.Protocol;

/// <summary>
/// Decodes source-protocol payloads into the six normalized process values
/// used by SignalForge.
///
/// Target values:
/// 1. Pressure1
/// 2. Pressure2
/// 3. TotalRate
/// 4. StageVolume
/// 5. JobVolume
/// 6. DensityOut
///
/// IMPORTANT: packet offsets, source byte order and packet-type semantics are
/// still being reverse engineered. They belong here and must not leak into
/// Runtime or Modbus code.
/// </summary>
public sealed class TelemetryDecoder
{
    public bool TryDecode(LlcPacket packet, out TelemetrySnapshot snapshot)
    {
        // TODO: Add confirmed offsets and decoding rules only after they have
        // been verified against captured traffic and known process values.
        // Do not guess field locations here.

        snapshot = TelemetrySnapshot.Empty with
        {
            Timestamp = packet.Timestamp
        };

        return false;
    }
}

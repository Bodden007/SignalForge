namespace SignalForge.Protocol;

public sealed record LlcPacket(
    DateTimeOffset Timestamp,
    byte Type,
    ReadOnlyMemory<byte> Payload);

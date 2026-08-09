using SignalForge.Capture;

namespace SignalForge.Protocol;

public sealed class LlcPacketParser : ILlcPacketParser
{
    private const byte Magic0 = 0xD0;
    private const byte Magic1 = 0x0D;
    private const int PacketTypeOffset = 9;

    public bool TryParse(CapturedFrame frame, out LlcPacket? packet)
    {
        var data = frame.Data.Span;

        if (data.Length <= PacketTypeOffset || data[0] != Magic0 || data[1] != Magic1)
        {
            packet = null;
            return false;
        }

        packet = new LlcPacket(
            frame.Timestamp,
            data[PacketTypeOffset],
            frame.Data);

        return true;
    }
}

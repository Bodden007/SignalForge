using SignalForge.Capture;

namespace SignalForge.Protocol;

public interface ILlcPacketParser
{
    bool TryParse(CapturedFrame frame, out LlcPacket? packet);
}

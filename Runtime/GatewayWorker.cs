using SignalForge.Capture;
using SignalForge.Protocol;

namespace SignalForge.Runtime;

public sealed class GatewayWorker(
    IPacketSource packetSource,
    ILlcPacketParser packetParser,
    TelemetryDecoder decoder,
    TelemetryStore telemetryStore)
{
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (var frame in packetSource.CaptureAsync(cancellationToken))
            {
                if (!packetParser.TryParse(frame, out var packet) || packet is null)
                    continue;

                if (decoder.TryDecode(packet, out var snapshot))
                    telemetryStore.Update(snapshot);
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            // Normal application shutdown. Do not report cancellation as a failure.
        }
    }
}

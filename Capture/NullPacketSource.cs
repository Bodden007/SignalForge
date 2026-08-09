using System.Runtime.CompilerServices;

namespace SignalForge.Capture;

/// <summary>
/// Placeholder packet source used until real capture hardware is available.
/// It intentionally produces no frames and remains alive until cancellation.
/// </summary>
public sealed class NullPacketSource : IPacketSource
{
    public async IAsyncEnumerable<CapturedFrame> CaptureAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Console.WriteLine("Packet capture is not implemented yet.");

        // Keep the source alive until the application requests shutdown.
        // Cancellation is expected control flow and is handled by GatewayWorker.
        await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);

        yield break;
    }
}

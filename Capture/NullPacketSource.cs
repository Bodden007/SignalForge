using System.Runtime.CompilerServices;

namespace SignalForge.Capture;

public sealed class NullPacketSource : IPacketSource
{
    public async IAsyncEnumerable<CapturedFrame> CaptureAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        Console.WriteLine("Packet capture is not implemented yet.");

        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000, cancellationToken);
            yield break;
        }
    }
}

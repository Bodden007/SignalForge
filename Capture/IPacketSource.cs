namespace SignalForge.Capture;

public interface IPacketSource
{
    IAsyncEnumerable<CapturedFrame> CaptureAsync(CancellationToken cancellationToken);
}

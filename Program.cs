using SignalForge.Capture;
using SignalForge.Modbus;
using SignalForge.Protocol;
using SignalForge.Runtime;

namespace SignalForge;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("SignalForge - Industrial Protocol Gateway");

        IPacketSource packetSource = new NullPacketSource();
        ILlcPacketParser packetParser = new LlcPacketParser();
        var decoder = new TelemetryDecoder();
        var telemetryStore = new TelemetryStore();
        var registerWriter = new ModbusRegisterWriter(telemetryStore);
        var modbusServer = new ModbusServer(registerWriter);
        var worker = new GatewayWorker(packetSource, packetParser, decoder, telemetryStore);

        using var cancellation = new CancellationTokenSource();
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true;
            cancellation.Cancel();
        };

        var modbusTask = modbusServer.RunAsync(cancellation.Token);
        var gatewayTask = worker.RunAsync(cancellation.Token);

        await Task.WhenAll(modbusTask, gatewayTask);
    }
}

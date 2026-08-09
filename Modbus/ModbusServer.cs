using System.Net;
using System.Net.Sockets;
using NModbus;

namespace SignalForge.Modbus;

public sealed class ModbusServer(ModbusRegisterWriter registerWriter)
{
    private const int Port = 502;
    private const byte SlaveId = 1;

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var listener = new TcpListener(IPAddress.Any, Port);
        listener.Start();

        var factory = new ModbusFactory();
        var network = factory.CreateSlaveNetwork(listener);
        var slave = factory.CreateSlave(SlaveId);
        network.AddSlave(slave);

        Console.WriteLine($"Modbus TCP server listening on port {Port}, slave {SlaveId}.");

        var listenTask = network.ListenAsync(cancellationToken);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                registerWriter.WriteTo(slave.DataStore);
                await Task.Delay(100, cancellationToken);
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        finally
        {
            listener.Stop();
        }

        await listenTask;
    }
}

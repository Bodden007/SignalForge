using NModbus;
using SignalForge.Runtime;

namespace SignalForge.Modbus;

public sealed class ModbusRegisterWriter(TelemetryStore telemetryStore)
{
    public void WriteTo(ISlaveDataStore dataStore)
    {
        var snapshot = telemetryStore.Current;

        WriteFloat(dataStore, RegisterMap.Pressure, snapshot.Pressure);
        WriteFloat(dataStore, RegisterMap.Temperature, snapshot.Temperature);
        WriteFloat(dataStore, RegisterMap.Density, snapshot.Density);
        WriteFloat(dataStore, RegisterMap.FlowRate, snapshot.FlowRate);
    }

    private static void WriteFloat(ISlaveDataStore dataStore, ushort address, float value)
    {
        var (lo, hi) = ModbusFloatConverter.ToRegisters(value);
        dataStore.HoldingRegisters.WritePoints(address, [lo, hi]);
    }
}

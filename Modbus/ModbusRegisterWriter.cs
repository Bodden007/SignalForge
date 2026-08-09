using NModbus;
using SignalForge.Runtime;

namespace SignalForge.Modbus;

/// <summary>
/// Copies the latest normalized telemetry snapshot into the NModbus
/// Holding Register data store.
///
/// This class does not know anything about the source LLC protocol.
/// Its only responsibility is mapping process values to Modbus registers.
/// MasterOPC reads these values from the Modbus TCP Slave using FC03.
/// </summary>
public sealed class ModbusRegisterWriter(TelemetryStore telemetryStore)
{
    public void WriteTo(ISlaveDataStore dataStore)
    {
        var snapshot = telemetryStore.Current;

        WriteFloat(dataStore, RegisterMap.Pressure1, snapshot.Pressure1);
        WriteFloat(dataStore, RegisterMap.Pressure2, snapshot.Pressure2);
        WriteFloat(dataStore, RegisterMap.TotalRate, snapshot.TotalRate);
        WriteFloat(dataStore, RegisterMap.StageVolume, snapshot.StageVolume);
        WriteFloat(dataStore, RegisterMap.JobVolume, snapshot.JobVolume);
        WriteFloat(dataStore, RegisterMap.DensityOut, snapshot.DensityOut);
    }

    /// <summary>
    /// Converts one 32-bit IEEE-754 float to two 16-bit Modbus registers
    /// and writes them to Holding Registers starting at the supplied address.
    /// Byte/word ordering is centralized in ModbusFloatConverter.
    /// </summary>
    private static void WriteFloat(ISlaveDataStore dataStore, ushort address, float value)
    {
        var (lo, hi) = ModbusFloatConverter.ToRegisters(value);
        dataStore.HoldingRegisters.WritePoints(address, [lo, hi]);
    }
}

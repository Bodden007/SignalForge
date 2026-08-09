namespace SignalForge.Modbus;

public static class ModbusFloatConverter
{
    public static (ushort Lo, ushort Hi) ToRegisters(float value)
    {
        var bytes = BitConverter.GetBytes(value);
        return (
            BitConverter.ToUInt16(bytes, 0),
            BitConverter.ToUInt16(bytes, 2));
    }
}

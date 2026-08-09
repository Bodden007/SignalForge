namespace SignalForge.Modbus;

/// <summary>
/// Converts IEEE-754 single-precision values to the two 16-bit registers used
/// by the tested MasterOPC/NModbus mapping.
///
/// The conversion works on the 32-bit representation directly and therefore
/// does not depend on the byte order of the machine running SignalForge.
/// </summary>
public static class ModbusFloatConverter
{
    public static (ushort Lo, ushort Hi) ToRegisters(float value)
    {
        var bits = BitConverter.SingleToUInt32Bits(value);

        var lo = (ushort)(bits & 0xFFFF);
        var hi = (ushort)(bits >> 16);

        return (lo, hi);
    }
}

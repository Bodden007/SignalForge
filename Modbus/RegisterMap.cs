namespace SignalForge.Modbus;

/// <summary>
/// Fixed Modbus Holding Register map exposed to MasterOPC.
/// Each IEEE-754 float occupies two consecutive 16-bit registers.
///
/// Register map is intentionally explicit and stable: changing these addresses
/// later would also require changing the MasterOPC configuration.
/// </summary>
public static class RegisterMap
{
    // Holding 0-1: first pressure.
    public const ushort Pressure1 = 0;

    // Holding 2-3: second pressure.
    public const ushort Pressure2 = 2;

    // Holding 4-5: total instantaneous rate.
    public const ushort TotalRate = 4;

    // Holding 6-7: volume pumped during the current stage.
    public const ushort StageVolume = 6;

    // Holding 8-9: volume pumped during the current job.
    public const ushort JobVolume = 8;

    // Holding 10-11: outlet density.
    public const ushort DensityOut = 10;
}

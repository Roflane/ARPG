using System;
using System.Runtime.InteropServices;

public static class RRandom {
    [DllImport("RRandom.dll")]
    public static extern UInt64 RandomUInt64(UInt64 min, UInt64 max);
    
    [DllImport("RRandom.dll")]
    public static extern UInt32 RandomUInt32(UInt32 min, UInt32 max);
    
    [DllImport("RRandom.dll")]
    public static extern UInt16 RandomUInt16(UInt16 min, UInt16 max);
    
    [DllImport("RRandom.dll")]
    public static extern Int64 RandomInt64(Int64 min, Int64 max);
    
    [DllImport("RRandom.dll")]
    public static extern Int32 RandomInt32(Int32 min, Int32 max);
    
    [DllImport("RRandom.dll")]
    public static extern Int16 RandomInt16(Int16 min, Int16 max);
    
    [DllImport("RRandom.dll")]
    public static extern Double RandomDouble(Double min, Double max);
    
    [DllImport("RRandom.dll")]
    public static extern Single RandomSingle(Single min, Single max);
}
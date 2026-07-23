namespace Ais.Net.Models.Benchmarks;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using BenchmarkDotNet.Attributes;

/// <summary>
/// Measures the cost of materialising a model record for a decoded message. Records are
/// reference types, so each message is at least one heap allocation (plus a nested
/// <see cref="Position"/> allocation for positional message types).
/// </summary>
[MemoryDiagnoser]
public class MessageConstructionBenchmarks
{
    [Benchmark]
    public AisMessageType1Through3 ClassAPositionReport() => new(
        CourseOverGround: 123.4f,
        ManoeuvreIndicator: ManoeuvreIndicator.NotAvailable,
        MessageType: 1,
        Mmsi: 235009802,
        NavigationStatus: NavigationStatus.UnderwayUsingEngine,
        Position: new Position(50.12345, -1.98765),
        PositionAccuracy: true,
        RadioSlotTimeout: 1,
        RadioSubMessage: 2,
        RadioSyncState: RadioSyncState.UtcDirect,
        RateOfTurn: 0,
        RaimFlag: false,
        RepeatIndicator: 0,
        SpareBits145: 0,
        SpeedOverGround: 12.3f,
        TimeStampSecond: 42,
        TrueHeadingDegrees: 181);

    [Benchmark]
    public AisMessageType24Part0 StaticDataReportPartA() => new(
        Mmsi: 235009802,
        PartNumber: 0,
        RepeatIndicator: 0,
        Spare160: 0);
}

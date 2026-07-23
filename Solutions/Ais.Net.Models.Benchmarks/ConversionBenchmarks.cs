namespace Ais.Net.Models.Benchmarks;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using BenchmarkDotNet.Attributes;

/// <summary>
/// Measures the pure numeric/enum helpers on the decode path. These are expected to be
/// branch-free-ish, sub-nanosecond, and allocation-free; the benchmark exists to prove that
/// and to catch regressions.
/// </summary>
[MemoryDiagnoser]
public class ConversionBenchmarks
{
    private const int LatitudeIn10000thMins = 30_000_000;   // 50 degrees
    private const int LatitudeIn10thMins = 30_000;          // 50 degrees
    private const uint SpeedRaw = 123;                      // 12.3 knots
    private const uint CourseRaw = 1234;                    // 123.4 degrees
    private const int RawShipType = 60;                    // Passenger, all ships

    [Benchmark]
    public double From10000thMinsToDegrees() => LatitudeIn10000thMins.From10000thMinsToDegrees();

    [Benchmark]
    public double From10thMinsToDegrees() => LatitudeIn10thMins.From10thMinsToDegrees();

    [Benchmark]
    public float? FromTenths() => SpeedRaw.FromTenths();

    [Benchmark]
    public float? FromTenthsToDegrees() => CourseRaw.FromTenthsToDegrees();

    [Benchmark]
    public ShipTypeGroup ToShipTypeGroup() => RawShipType.ToShipTypeGroup();

    [Benchmark]
    public ShipTypeCategory ToShipTypeCategory() => ((ShipType)RawShipType).ToShipTypeCategory();

    [Benchmark]
    public string ToShipTypeDescription() => RawShipType.ToShipTypeDescription();
}

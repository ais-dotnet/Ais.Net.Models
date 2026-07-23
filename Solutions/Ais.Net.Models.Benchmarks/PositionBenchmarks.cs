namespace Ais.Net.Models.Benchmarks;

using Ais.Net.Models.Abstractions;

using BenchmarkDotNet.Attributes;

/// <summary>
/// Quantifies the cost of <see cref="Position"/> being a <c>record</c> (reference type). Every
/// decoded position is a heap allocation. The struct variant models the proposed
/// <c>readonly record struct</c> change to show the allocation saving on the decode path.
/// </summary>
[MemoryDiagnoser]
public class PositionBenchmarks
{
    private const double Latitude = 50.12345;
    private const double Longitude = -1.98765;

    [Benchmark(Baseline = true)]
    public Position RecordClass() => new(Latitude, Longitude);

    [Benchmark]
    public PositionValue RecordStruct() => new(Latitude, Longitude);

    /// <summary>Models <see cref="Position"/> reworked as a value type.</summary>
    public readonly record struct PositionValue(double Latitude, double Longitude);
}

namespace Ais.Net.Models.Benchmarks;

using Ais.Net.Models.Abstractions;

using BenchmarkDotNet.Attributes;

/// <summary>
/// Confirms that constructing a <see cref="Position"/> is allocation-free. It was reworked from a
/// <c>record</c> (reference type, 32 B per instance) to a <c>readonly record struct</c>, so this
/// benchmark guards against a regression back to heap allocation.
/// </summary>
[MemoryDiagnoser]
public class PositionBenchmarks
{
    private const double Latitude = 50.12345;
    private const double Longitude = -1.98765;

    [Benchmark]
    public Position Construct() => new(Latitude, Longitude);

    [Benchmark]
    public Position FromTenThousandthsOfMinutes() => Position.From10000thMins(30_000_000, 60_000_000);
}

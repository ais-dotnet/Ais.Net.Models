namespace Ais.Net.Models.Benchmarks;

using System;

using Ais.Net.Models;

using BenchmarkDotNet.Attributes;

/// <summary>
/// Compares vessel-name cleaning strategies. The production method currently uses
/// <c>Trim(...).Split(...).Join(...)</c> which allocates a temporary trimmed string, an array,
/// and one substring per word. The span-based variant produces exactly one string (the result)
/// using a stack buffer, and is the proposed replacement.
/// </summary>
[MemoryDiagnoser]
public class VesselNameBenchmarks
{
    // A raw 20-character AIS name field: text plus '@' padding (the common case).
    [Params("EVER GIVEN", "EVER GIVEN@@@@@@@@@@", "QUEEN  MARY   2@@@@@", "@@@@@@@@@@@@@@@@@@@@")]
    public string RawName { get; set; } = string.Empty;

    // The previous implementation, kept as the baseline to show the improvement.
    [Benchmark(Baseline = true)]
    public string Old_SplitJoin()
    {
        string trimmed = this.RawName.Trim('@', ' ');
        return string.Join(' ', trimmed.Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    // The shipped implementation.
    [Benchmark]
    public string Current_Span() => this.RawName.CleanVesselName();
}

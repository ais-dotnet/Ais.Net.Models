using BenchmarkDotNet.Running;

// Use the switcher so individual benchmark classes/methods can be selected via --filter,
// e.g. dotnet run -c Release -- --filter *VesselName*
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

public partial class Program
{
}
